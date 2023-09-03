using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        /// <summary>
        /// 反射：
        ///     1. 什么是反射/反编译
        ///     2. 反射创建对象
        ///     3. 反射 + 工厂 + 配置文件断开对细节依赖
        ///     4. 反射黑科技
        ///     5. 反射调用方法
        ///     6. 反射多种场景应用
        ///     7. 反射的局限/性能问题
        ///     8. 反射操作属性字段
        ///     9. 反射 + ADO.NET实现数据库访问层
        ///     10. 反射的Emit的技术
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎来到高级班进阶学习，本项目学习反射技术");
            try
            {
                #region 什么是反射/反编译

                // 反射反射程序员的快乐，反射无处不在。比如：封装框架，系统开发，MVC，IOC，ORM
                {
                    // 一、反射/反编译工具/高级语言到计算机语言的历程：
                    // 1. 高级语言 => 编译器编译 => dll/exe文件(metadata、IL) => CLR/JIT => 机器码01010101
                    // 2. dll/exe文件包含 metadata 和 IL。metadata：元数据（数据清单）--记录了d ll中包含哪些东西，是一个描述
                    // 3. IL：中间语言 --编译器把高级语言编译后得到的C#中最真实的语言状态，面向对象语言
                    // 4. 反编译工具：逆向工程： ILSpy -- dll/exe ---反编译回来，C#/IL
                    // 5. 反射：来自于System.Reflection，是一个帮助类库 --可以读取dll/exe中的metadata（元数据）和使用metadata、还可以动态的创建dll/exe  ---Emit技术;
                }

                #endregion

                //#region 二、反射创建对象
                //{
                //    // 1.传统方式调用
                //    IDBHelper dBHelper = new SqlServerHelper();
                //    dBHelper.Query();

                //    // 2.反射调用
                //    //  1.动态读取Dll三种方式：
                //    //      1、LoadFrom：全名称，需要后缀
                //    //      2、LoadFile：全路径，需要后缀
                //    //      3、Load：dll名称 不需要后缀
                //    Assembly assembly = Assembly.LoadFrom("Business.DB.SqlServer.dll");
                //    // Assembly assembly1 = Assembly.LoadFile(@"D:\Coding\.Net\朝夕15期高级班项目\MyReflection_反射\MyReflection\bin\Debug\net6.0\Business.DB.SqlServer.dll");
                //    // Assembly assembly2 = Assembly.LoadFile("Business.DB.SqlServer");
                //    Console.WriteLine("***********************************************");
                //    //foreach (Type type in assembly.GetTypes())
                //    //{
                //    //    Console.WriteLine(type.FullName);
                //    //    foreach (var method in type.GetMethods())
                //    //    {
                //    //        Console.WriteLine(method.Name);
                //    //    }

                //    //    foreach (var fild in type.GetFields())
                //    //    {
                //    //        Console.WriteLine(fild.Name);
                //    //    }
                //    //}
                //    Console.WriteLine("***********************************************");

                //    // 2.获取某一个具体的类：参数需要是类的全名称
                //    Type type = assembly.GetType("Business.DB.SqlServer.SqlServerHelper");

                //    // 3.创建对象
                //    object? oInstance = Activator.CreateInstance(type);
                //    // object? oInstance1 = Activator.CreateInstance("Business.DB.SqlServer.dll", "Business.DB.SqlServer.SqlServerHelper");
                //    // oInstance.Query();  // 报错：因为oInstance当作是是一个object类型，没有Query方法；C#语言是一种强类型语言，编译时决定是什么类型，以左边为准；不能调用是因为编译器不允许；实际类型一定是SqlServerHelper；

                //    // 如果使用dynamic 作为类型声明，在调用的时候没有限制；
                //    // dynamic:动态类型，不是编译时决定类型，避开编译器的检查；运行时决定是什么类型；
                //    //dynamic dInstance = Activator.CreateInstance(type);
                //    //dInstance.Query();
                //    //dInstance.Show(); // 报错，是因为SqlServerHelper没有Get方法

                //    // 4.类型转换
                //    // SqlServerHelper helper = (SqlServerHelper)oInstance;    // 不建议这样转换，如果真实类型不一致会报错
                //    SqlServerHelper helper = oInstance as SqlServerHelper; // 如果类型一直就转换，如果不一致就返回null;

                //    // 5.s调用方法
                //    helper.Query();

                //    // 经过5步骤，千辛万苦终于调用到query方法

                //    // 问题：反射不是很牛逼吗？ 无处不在？ 就这？
                //    // 1.代码好多 --在面向对象以后，代码多不是事。
                //    // 2.封装 继承 多态
                //    // 3.代码多就封装
                //}
                //#endregion

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}