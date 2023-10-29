using MySql.Data.MySqlClient;
using Zhaoxi.DbProxy.Model;

namespace Zhaoxi.DbProxy {

    /// <summary>
    /// 用来操作数据的核心代理
    /// 增删改查
    /// 
    /// 1. 先来一个查询 -- 基于主键查询
    /// </summary>
    public class DBProxyCore {

        ///// <summary>
        ///// 主键查询 --学习过程
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Commodity GetCommodity(int id) {

        //    Commodity commodity = new Commodity();

        //    string ConnectionString = "server=127.0.0.1;user id=root;password=000000;database=zhaoxipracticedb";
        //    using MySqlConnection connection = new MySqlConnection(ConnectionString);     // 网络资源， using会自动回收资源
        //    connection.Open();

        //    string sql = @"select * from commodity where id = " + id;
        //    MySqlCommand sqlCommand = connection.CreateCommand();
        //    sqlCommand.CommandText = sql;
        //    MySqlDataReader reader = sqlCommand.ExecuteReader();  // 数据集读取器

        //    // 读取是否有数据
        //    if (reader.Read()) {
        //        commodity.Id = Convert.ToInt32(reader["Id"]);
        //        commodity.ProductId = Convert.ToInt32(reader["ProductId"]);
        //        commodity.CategoryId = Convert.ToInt32(reader["CategoryId"]);
        //        commodity.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
        //        commodity.Price = Convert.ToDecimal(reader["Price"]); ;
        //        commodity.ImageUrl = reader["ImageUrl"].ToString();
        //        commodity.Url = reader["Url"].ToString();
        //    }

        //    connection.Close();


        //    return commodity;
        //}

        // 如果要查询Company --难道再来一个GetCompany方法吗？数据库表会有很多，随着开发数据表会更多，这种方法根本写不完。
        // 能不能想办法合并一下，一个方法满足不同实体通用的查询诉求。 -- 有，泛型

        /// <summary>
        /// 主键查询 --仅仅是主键查询，任何类型都可以调用这个方法，并且一定要传递主键进来，才能查询。
        /// 根据泛型 和 反射优化的通用版本
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : BaseModel {

            //T model = new T();
            Type type = typeof(T);
            object? oResult = Activator.CreateInstance(type);   // 反射创建对象，调用的是无参数构造函数

            string ConnectionString = "server=127.0.0.1;user id=root;password=000000;database=zhaoxipracticedb";
            using MySqlConnection connection = new MySqlConnection(ConnectionString);     // 网络资源， using会自动回收资源
            connection.Open();

            // 固定写死表名的查询sql，需要优化为动态表名
            //string sql = @"select * from commodity where id = " + id;

            // 动态查询表名
            // sql语句应该依赖于泛型T，根据T自动生成不同表名的sql语句

            //string sql = @"select { 以逗号分割的数据库表的字段名称 } from { 数据库表的表名称 } where id = " + id;
            // 1.传入的类型不同，就会即时通过反射来动态生成sql语句
            // 2.反射 --局限？反射是比较损耗性能的
            // 3.这里的sql语句生成是很损耗性能额
            // 4.性能损耗能否优化？ -- 缓存？思考下。
            string sql = $"select {string.Join(", ", type.GetProperties().Select(c => c.Name).ToList())} from {type.Name.ToLower()} where id = " + id + ";";

            MySqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = sql;
            MySqlDataReader reader = sqlCommand.ExecuteReader();  // 数据集读取器

            // 读取是否有数据
            if (reader.Read()) {
                //commodity.Id = Convert.ToInt32(reader["Id"]);
                //commodity.ProductId = Convert.ToInt32(reader["ProductId"]);
                //commodity.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                //commodity.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                //commodity.Price = Convert.ToDecimal(reader["Price"]); ;
                //commodity.ImageUrl = reader["ImageUrl"].ToString();
                //commodity.Url = reader["Url"].ToString();
                // 通过反射来完成

                // 反射如何给对象的属性或字段赋值
                // 1.获取属性
                // 2.通过属性对象调用setValue方法

                // 循环便利所有的属性，逐个给属性赋值，必须把对应字段的值赋值给对应的对象属性的值
                foreach (var prop in type.GetProperties()) {
                    //if (prop.Name.Equals("Id")) {
                    //    prop.SetValue(oResult, Convert.ToInt32(reader["Id"]));
                    //} else if (prop.Name.Equals("ProductId")) {
                    //    prop.SetValue(oResult, reader["ProductId"]);
                    //} else if (prop.Name.Equals("CategoryId")) {
                    //    prop.SetValue(oResult, Convert.ToInt32(reader[prop.Name]));
                    //} else if (prop.Name.Equals("CreateTime")) {
                    //    prop.SetValue(oResult, Convert.ToDateTime(reader[prop.Name]));
                    //} else if (prop.Name.Equals("Price")) {
                    //    prop.SetValue(oResult, Convert.ToDecimal(reader[prop.Name]));
                    //} else if (prop.Name.Equals("ImageUrl")) {
                    //    prop.SetValue(oResult, reader[prop.Name]);
                    //} else if (prop.Name.Equals("Url")) {
                    //    prop.SetValue(oResult, reader[prop.Name]);
                    //}

                    // 改进避免循环赋值
                    //prop.SetValue(oResult, reader[prop.Name]);

                    // 如果数据库表中的某一个字段为null, reader[prop.Name]获取到的数据类型为DBNull --在C#程序中的代表是null；但是在C#程序中null不能直接使用DBNull来替换；
                    prop.SetValue(oResult, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                }

            }
            return (T)oResult;
        }




    }
}