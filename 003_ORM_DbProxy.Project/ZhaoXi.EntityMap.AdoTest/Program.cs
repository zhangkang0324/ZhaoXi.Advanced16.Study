using MySql.Data.MySqlClient;
using System;

namespace ZhaoXi.EntityMap.AdoTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("===================================");
                Console.WriteLine("欢迎来到.Net高级班的Vip课程，今天学习ORM框架");
                Console.WriteLine("===================================");

                #region ORM框架是什么？

                // ORM框架是什么？
                // ORM--操作数据库--数据关系映射
                // 采用元数据来描述对象与关系映射的细节。只要提供了持久化类与表的映射关系，ORM框架在运行时就能参照映射文件的信息，把对象持久化到数据库中。
                // 设计思想上：只关心对象了，不关注什么命令（sql语句） --需要做任何操作都已面向对象的思想去操作--通过映射--操作对象--落实到数据库中去； 
                // 核心就是：以面向对象的思想去完成数据库的操作。
                // 底层实现一定还是要执行Sql语句的--底层其实还是Ado.Net，ORM框架是基于Ado.Net的上层封装；
                // ORM某种意义上说相当于是一个代理。

                #endregion

                #region Ado.Net：早期的数据库操作。

                // Ado.Net：早期的数据库操作。
                //  名称起源于（Active Data Objects）是一个COM组件库，用于在以往的Microsoft技术中访问数据，之所以使用Ado.Net名称，是因为Microsoft希望表明，这是在Net编程环境中优先使用的数据访问接口。
                // 关系型数据库而言--只认识Sql语句
                // SqlConnection（用户名称 + 密码）
                // SqlCommand 命令执行对象（传递命令）
                // 数据库命令执行完成--最终的结果，呈现出结果集（查询）/ 受影响的行数（）
                //  1.连接数据库：
                //  2.传递Sql语句：
                //  3.数据库执行Sql语句：
                //  4.返回执行结果

                // ADO.NET组成：
                //  SqlConnection （数据库连接器）
                //  SqlCommand（数据库命名对象）
                //  SqlCommandBuilder（生成SQL命令）
                //  SqlDataReader（数据库读取器）
                //  SqlDataAdapter（数据适配器填充）
                //  SqlParameter（为存储过程定义参数）
                //  SqlTransactin（数据库事务）

                #endregion

                #region  ADO VS ORM

                //ADO VS ORM
                //ADO：
                //1.大量的Sql语句--业务不同，Sql语句不同
                //2.需要根据不同的场景编写不同的代码--灵活的去编写Sql语句--提前优化Sql--提供高性能的Sql语句
                //3.不适合快速开发--
                //4.可编程性--更加灵活（对于高级开发，全方位发展的）
                //5.高性能--原生--接近于底层--没有过多的封装

                //ORM：
                //1.上手快--技术可以更加单一
                //2.不用关注数据库，不关注Sql语句--降低了开发升本
                //3.关注对象，以对象为核心
                //4.适合快速开发构建--提供更多的功能--代码生成器--映射关系的配置快速构建
                //5.性能有争议--相比Ado.Net性能低
                //6.生成的Sql语句 相对僵化--ORM（通用性强）

                //ORM性能争议有哪些？
                //1.二次封装--业务的执行，步骤多一些
                //2.映射的过程--必然从类到Sql语句的转化--如何把类转换为Sql语句？ --必然会有大量的反射（性能损耗）
                //3.Sql语句僵化--数据库执行会有性能损耗

                // 以上问题有部分是可以解决的。（例如引入缓存）

                #endregion

                // ADO.NET --引入程序集 --Nuget
                // SqlConnection
                string ConnectionString = "server=localhost;database=advancednet6;user=root;password=123456;";
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}