using Business.DB.Interface;
using Business.DB.MySql;
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
                #region 1. 什么是反射/反编译

                // 反射反射程序员的快乐，反射无处不在。比如：封装框架，系统开发，MVC，IOC，ORM
                {
                    // 一、反射/反编译工具/高级语言到计算机语言的历程：
                    // 1. 高级语言 => 编译器编译 => dll/exe文件(metadata、IL) => CLR/JIT => 机器码01010101
                    // 2. metadata：元数据（数据清单）--记录了dll中包含哪些东西，是一个描述
                    // 3. IL：中间语言 --编译器把高级语言编译后得到的C#中最真实的语言状态，面向对象语言
                    // 4. 反编译工具：逆向工程： ILSpy_binaries_8.1.0.7455-x64 -- dll/exe ---反编译回来，C#/IL
                    // 5. 反射：是一个帮助类库,来自于System.Reflection，--可以读取dll/exe中的metadata（元数据）和使用metadata + 动态的创建dll/exe + ---Emit技术;
                }

                #endregion

                #region 2. 反射创建对象

                // 反射创建对象
                {
                    // 传统工艺
                    IDBHelper dbHelper = new MySqlHelper();
                    dbHelper.Query();

                    // 反射
                    //1. 动态读取 DLL 的三种方式： 1.LoadFrom：dll全名称 需要后缀； 2.LoadFile：全路径，需要dll后缀； 3. Load：dll名称 不需要后缀；
                    Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll"); // dll全名称
                    // Assembly assembly1 = Assembly.LoadFile("E:\\Coding\\.Net\\ZhaoXi.Advanced16.Study\\002_Reflection_反射\\Reflection\\bin\\Debug\\net6.0\\Business.DB.MySql.dll");
                    // Assembly assembly2 = Assembly.Load("Business.DB.MySql");

                    Console.WriteLine("***********************************************");

                    // 循环查看所有的 类、方法、属性
                    //foreach (Type t in assembly.GetTypes())
                    //{
                    //    Console.WriteLine($"FullName：{t.FullName}");

                    //    foreach (var method in t.GetMethods())
                    //    {
                    //        Console.WriteLine($"method Name: {method.Name}");
                    //    }

                    //    foreach (var fild in t.GetFields())
                    //    {
                    //        Console.WriteLine($"fild Name: {fild.Name}");
                    //    }
                    //}
                    Console.WriteLine("***********************************************");


                    // 2. 获取某一个具体的类型：参数需要类的全名称；
                    Type type = assembly.GetType("Business.DB.MySql.MySqlHelper");  // 

                    // 3. 创建对象
                    object? oInstance = Activator.CreateInstance(type);
                    // object? oInstance1 = Activator.CreateInstance("Business.DB.MySql", "Business.DB.MySql.MySqlHelper");  // dll名称 不需要后缀(加后缀会报错)

                    // oInstance.Query();  // 报错，因为 oInstance 当作是是一个object类型，没有Query方法；C#语言是一种强类型语言。编译时决定时什么类型，以左边为准；不能调用时因为编译器不允许；实际类型一定时MySqlHelper；

                    // 那要如何调用执行呢？ 使用 dynamic 动态类型;
                    // 如果使用 dynamic 作为类型的声明，在调用的时候，没有限制。
                    dynamic dInstance = Activator.CreateInstance(type);
                    dInstance.Query();
                    // dynamic：是动态类型，不是编译时决定类型，避开编译器的检查；运行时决定是什么类型；
                    // dInstance.Get();    // 报错了 -- 因为MysqlHelper没有Get方法


                    // 4. 类型转换
                    // MySqlHelper helper = (MySqlHelper)oInstance;    // 不建议这样转换，如果真实类型不一致会报错
                    //MySqlHelper helper = oInstance as MySqlHelper; // 如果类型一致就转换，如果不一致就返回null;
                    IDBHelper helper = oInstance as IDBHelper; // 如果类型一致就转换，如果不一致就返回null;

                    // 5.s调用方法
                    // helper.Get();  //调用会报错，因为方法不存在
                    helper.Query();

                    // 经过5步骤，千辛万苦终于调用到query方法


                    // 问题：反射不是很牛逼吗？ 无处不在？ 就这？
                    // 1.代码好多 -- 在面向对象以后，代码多不是事;
                    // 2.封装  继承  多态
                    // 3.代码多就封装

                    {
                        SimpleFactory.CreateInstance();
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}