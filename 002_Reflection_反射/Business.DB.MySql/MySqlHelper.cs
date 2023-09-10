using Business.DB.Interface;
using Business.DB.Model;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Business.DB.MySql
{
    public class MySqlHelper : IDBHelper
    {
        private string ConnectionString = "server=localhost;database=zhaoxipracticedb;user=root;password=000000;";

        public MySqlHelper()
        {
            Console.WriteLine($"{this.GetType().Name} 被构造.");
        }

        public MySqlHelper(int i)
        {
            Console.WriteLine($"{this.GetType().Name} 被构造.");
        }

        public void Query()
        {
            Console.WriteLine($"{this.GetType().Name} .Query");
        }

        /// <summary>
        /// 查询Company
        /// 条件： 1.必须有一个Id字段，通过继承BaseModel；  2.要求实体对象中的属性结构必须和数据库完全一致；
        /// </summary>
        public SysCompany QuerySysCompany(int id)
        {
            // 开始ORM
            // 1.连接数据库字符串 ConnectionString

            // SysCompany result = new SysCompany();  // 这样不行，使用反射的方式
            //  7. 反射创建对象oResult --给oResult赋值然后返回这个oResult（此处穿插第7步）
            Type type = typeof(SysCompany);
            object oResult = Activator.CreateInstance(type);


            // 2. 准备 MySqlConnection，使用数据库连接字符串 
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                Console.WriteLine("打开数据库连接...");
                conn.Open();

                // 3. 准备查询的sql语句
                string stringSql = @"SELECT	s.id, s.`NAME`, s.CreateTime, s.CreatorId, s.LastModifyId, s.LastModifyTime
                                    FROM		zhaoxipracticedb.syscompany s where s.Id = " + id;

                // 4. 准备 MySqlCommand 对象
                MySqlCommand cmd = new MySqlCommand(stringSql, conn);

                // 5. 通过MySqlCommand对象 执行Sql语句
                MySqlDataReader reader = cmd.ExecuteReader();

                // 6. 开始获取数据
                if (reader.Read())
                {
                    //object oId = reader["Id"];
                    //result.Id = Convert.ToInt32(reader["Id"]);    // 不行,手动写赋值代码，每次都得修改
                    //object oName = reader["Name"];
                    //result.Name = reader["Name"].ToString();  // 不行，手动写赋值代码，每次都得修改

                    // 问题来了，数据可以查询到 --需要返回一个对象 --要赋值给SysCompany对象，然后返回此对象； --可以使用反射更方便赋值
                    // 7步骤跳转到方法最上部分

                    // 8. 使用反射赋值
                    foreach (var prop in type.GetProperties())
                    {
                        //if (prop.Name.Equals("Id"))
                        //{
                        //    prop.SetValue(oResult, reader["Id"]);
                        //}
                        //else if (prop.Name.Equals("Name"))
                        //{
                        //    prop.SetValue(oResult, reader["Name"]);
                        //}
                        //else if (prop.Name.Equals("CreateTime"))
                        //{
                        //    prop.SetValue(oResult, reader["CreateTime"]);
                        //}
                        //else if{ } // ......

                        // 因为 prop.Name.Equals("Id") 和 reader["Id"] 是同一个名称，所以此处的循环判断可优化：
                        prop.SetValue(oResult, reader[prop.Name]);
                    }
                }
                cmd.Dispose();
                conn.Close();
            }
            return (SysCompany)oResult;
        }

        /// <summary>
        /// 
        /// 如果希望一个方法满足不同类型的需求，那就是泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Find<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            object oResult = Activator.CreateInstance(type);


            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                //string stringSql = @"SELECT	s.id, s.`NAME`, s.CreateTime, s.CreatorId, s.LastModifyId, s.LastModifyTime
                //                    FROM		zhaoxipracticedb.syscompany s where s.Id = " + id;

                // 这条sql语句是干嘛的？ -- 是专门查询 syscompany 表的
                // 问题：需要通过泛型T 来动态的生成sql语句
                //string stringSql = "select {字段} from {表名} where id = " + id;
                // 需要通过泛型T 来动态生成查询的字段，表名称

                // List<string> propList = type.GetProperties().Select(s => $"`{s.Name}`").ToList();
                //string props = string.Join(',', propList);
                // string stringSql = $"select {string.Join(',', type.GetProperties().Select(s => $"`{s.Name}`").ToList())} from {type.Name} where id = {id};";

                // 如果查询SysCompany 10次，每一次来查询都要生成sql语句 --
                // 就算是查询10次，其实sql语句都是一样的；最多就是查询条件不一样
                // 查询10次 --生成10次 --都i是同一个操作 --怎么优化一下？

                // 泛型缓存：避免为了同一个类型，多次去生成sql语句
                //          提高性能
                string stringSql = ConstantSqlString<T>.GetSql(id);

                MySqlCommand cmd = new MySqlCommand(stringSql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oResult, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                }
                cmd.Dispose();
                conn.Close();
            }
            return (T)oResult;
        }

    }
}