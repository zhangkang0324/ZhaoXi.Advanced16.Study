using Business.DB.Interface;
using Business.DB.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Business.DB.SqlServer
{
    public class SqlServerHelper : IDBHelper
    {

        //Nuget:System.Data.SqlClient

        private string ConnectionString = "Data Source=DESKTOP-VUL99EF; Database=ZhaoXiPracticeDB; User ID=sa; Password=sa123; MultipleActiveResultSets=True";

        private static string GetConnection()
        {
            //Nuget引入：
            //SetBasePath:Microsoft.Extensions.Configuration.FileExtensions
            //AddJsonFile:Microsoft.Extensions.Configuration.Json 
            var Configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true)
             .Build();
            return Configuration.GetConnectionString("Default");
        }


        public SqlServerHelper()
        {
            //Console.WriteLine($"{this.GetType().Name}被构造");
        }

        //public SqlServerHelper(int i)
        //{
        //    Console.WriteLine($"{this.GetType().Name}被构造");
        //}

        public void Query()
        {
            //Console.WriteLine($"{this.GetType().Name}.Query");
        }

        /// <summary>
        /// 查询Company
        /// 条件：
        /// 1.必须有一个Id字段--继承BaseModel
        /// 2.要求实体对象中的属性结构必须和数据完全一致
        /// </summary>
        public SysCompany QuerySysCompany(int id)
        {
            //开始ORM
            //1.链接数据---数据库链接字符串ConnectionString 
            //2.准备SqlConnection，使用数据库链接字符串

            //SysCompany result = new SysCompany();
            //7.反射创建对象oReulst--- 给oReulst 赋值然后返回  oReulst
            Type type = typeof(SysCompany);
            object oReulst = Activator.CreateInstance(type);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();//打开数据库链接
                //3.准时Sql语句
                #region MyRegion
                string sql = @"SELECT [Id]
                                  ,[Name]
                                  ,[CreateTime]
                                  ,[CreatorId]
                                  ,[LastModifierId]
                                  ,[LastModifyTime]
                              FROM [ZhaoXiPracticeDB].[dbo].[SysCompany] where  id=" + id;
                #endregion 
                //4.准备SqlCommand
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                //5.通过SqlCommand对象执行Sql语句
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //6.开始获取数据

                if (reader.Read())
                {
                    //object oId = reader["Id"];
                    //result.Id = Convert.ToInt32(oId);//不行；
                    //object oName = reader["Name"]; 
                    //8.反射赋值？
                    foreach (var prop in type.GetProperties())
                    {
                        //if (prop.Name.Equals("Id"))
                        //{
                        //    prop.SetValue(oReulst, reader["Id"]); //Id
                        //}
                        //else if (prop.Name.Equals("Name"))
                        //{
                        //    prop.SetValue(oReulst, reader[prop.Name]);
                        //}
                        //else if (prop.Name.Equals("CreateTime"))
                        //{
                        //    prop.SetValue(oReulst, reader[prop.Name);
                        //}

                        //else if (true)
                        //{
                        //.......
                        //}

                        prop.SetValue(oReulst, reader[prop.Name]);
                    }
                }
                //问题来了,数据可以查询到---需要返回一个对象--需要赋值给对象，然后返回对象；----反射 
            }
            return (SysCompany)oReulst;
        }


        /// <summary> 
        ///如果希望一个方法满足不同类型的需求，那就泛型方法；
        /// </summary>
        public T Find<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            object oReulst = Activator.CreateInstance(type);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                #region MyRegion
                //string sql = @"SELECT [Id]
                //                  ,[Name]
                //                  ,[CreateTime]
                //                  ,[CreatorId]
                //                  ,[LastModifierId]
                //                  ,[LastModifyTime]
                //              FROM [ZhaoXiPracticeDB].[dbo].[SysCompany] where  id=" + id; 
                //这条Sql语句是干嘛的？---SysCompany专属Sql语句
                //问题：需要通过泛型T 来动态的生成Sql语句 
                //string sql = "Select {'',''} from {表名称} where id=" + id;
                //需要通过泛型T 来动态的生成查询的字段，表名称
                //List<string> propList = type.GetProperties().Select(c => $"[{c.Name}]").ToList(); 
                //string props = string.Join(',', propList);  
                #endregion

                //如果查询SysCompany 10 次；  每次来查询，都要生成Sql语句；
                //就算是查询10次，其实Sql语句都一样的；最多就是查询条件不一样
                //查询10 --生成10次---都是同一个类型；---怎么优化一下？

                //泛型缓存：避免为了同一个类型，多次去生成Sql语句
                //          提高性能

                //string sql = $"Select {string.Join(',', type.GetProperties().Select(c => $"[{c.Name}]").ToList())} from {type.Name} where id=" + id; 
                string sql = ConstantSqlString<T>.GetFindSql(id); 
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oReulst, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                }
                //问题来了,数据可以查询到---需要返回一个对象--需要赋值给对象，然后返回对象；----反射 
            }
            return (T)oReulst;
        }

    }
}
