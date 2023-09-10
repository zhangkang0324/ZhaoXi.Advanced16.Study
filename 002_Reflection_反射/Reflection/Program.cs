using Business.DB.Interface;
using Business.DB.Model;
using Business.DB.MySql;
//using Business.DB.SqlServer;
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
                Console.WriteLine("1. 什么是反射/反编译");

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
                Console.WriteLine("2. 反射创建对象");

                // 反射创建对象
                {
                    // 传统工艺
                    //IDBHelper dbHelper = new MySqlHelper();
                    //IDBHelper dbHelper = new SqlServerHelper();
                    //dbHelper.Query();

                    {
                        // 反射
                        //1. 动态读取 DLL 的三种方式： 1.LoadFrom：dll全名称 需要后缀； 2.LoadFile：全路径，需要dll后缀； 3. Load：dll名称 不需要后缀；
                        Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll"); // dll全名称
                        // // Assembly assembly1 = Assembly.LoadFile("E:\\Coding\\.Net\\ZhaoXi.Advanced16.Study\\002_Reflection_反射\\Reflection\\bin\\Debug\\net6.0\\Business.DB.MySql.dll");
                        // // Assembly assembly2 = Assembly.Load("Business.DB.MySql");

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

                    }
                }

                #endregion

                #region 3. 反射 + 工厂 + 配置文件断开对细节依赖
                Console.WriteLine("3. 反射 + 工厂 + 配置文件断开对细节依赖");

                {
                    IDBHelper helper1 = SimpleFactory.CreateInstance();
                    helper1.Query();
                    // 为什么要这样做呢？
                    // 1. 如果公司来了一个新的技术经理：--SqlServer --MySql
                    // 2. 传统方式：必须要修改代码--必须要重新发布 编译 发布到服务器 --步骤会很多
                    // 3. 反射实现：断开了对普通类（细节）的依赖，只依赖接口（抽象）与配置文件 

                    // MySql --> 修改为 SqlServer
                    //a. 按照接口约定实现一个SqlServer帮助类库
                    //b. Copy dll文件到执行目录下
                    //c. 修改配置文件

                    // 结果：不同功能额灵活切换--程序的配置
                    //       如果经理修改 MySql -- Orcale，只需要增加对应Oracle的类以及配置文件即可。分开两者的依赖。
                    //      如果一个新的功能不存在，只需要把功能实现、dll copy到执行目录下修改配置文件。 -- 不需要停止程序的运行；扩展一个新的功能进来。
                    //      程序的可扩展。
                }

                #endregion

                #region 4. 反射黑科技 
                Console.WriteLine("4. 反射黑科技 ");

                // 反射可以做到普通方法做不到的事  -- 反射破坏单例
                {
                    {
                        Singleton singleton1 = Singleton.GetInstance();
                        Singleton singleton2 = Singleton.GetInstance();
                        Singleton singleton3 = Singleton.GetInstance();
                        Singleton singleton4 = Singleton.GetInstance();
                        // 单例模式有个特点：整个进程中都是同一个实例。
                        Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
                        Console.WriteLine(object.ReferenceEquals(singleton2, singleton3));
                        Console.WriteLine(object.ReferenceEquals(singleton1, singleton4));
                    }
                    // new Singleton();  // 无法访问，因为具有一定保护级别；单例模式。

                    // 如果有私有化修饰 -- 除了反射以外，没有其他方法来完成对私有化的访问；私有化的就只能从内部访问；
                    // 反射的强大之处 -- 可以做到普通方法做不到的事情；反射动态加载dll文件，只要元数据中有的，都可以找出来； 完全不用关注权限问题； -- 为所欲为 --像一个小暗门；
                    {
                        Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll");
                        Type type = assembly.GetType("Business.DB.MySql.Singleton");
                        Singleton Singleton1 = (Singleton)Activator.CreateInstance(type, true);
                        Singleton Singleton2 = (Singleton)Activator.CreateInstance(type, true);
                        Singleton Singleton3 = (Singleton)Activator.CreateInstance(type, true);
                        Singleton Singleton4 = (Singleton)Activator.CreateInstance(type, true);
                        Console.WriteLine(object.ReferenceEquals(Singleton1, Singleton2));
                        Console.WriteLine(object.ReferenceEquals(Singleton2, Singleton3));
                        Console.WriteLine(object.ReferenceEquals(Singleton3, Singleton4));
                    }
                }

                #endregion

                #region 5. 反射调用方法 + 反射创建对象的升级篇
                Console.WriteLine("5. 反射调用方法 + 反射创建对象的升级篇 ");

                // 5-1. 创建对象的升级篇
                {
                    // Type type = null;
                    // Activator.CreateInstance(); // 访问的是无参数构造函数创建对象
                    // 如何访问有参构造函数呢？
                    Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll");
                    Type type = assembly.GetType("Business.DB.MySql.ReflectionTest");
                    // a. 调用无参数构造函数
                    object noParaObject = Activator.CreateInstance(type);

                    // b. 调用有参数构造函数 --需要传递一个object类型的数组作为参数，蚕食按照从左往右匹配；严格匹配，按照参数的类型去执行对应的和参数类型匹配的构造函数，如果没有匹配的则报异常；
                    object paraObject = Activator.CreateInstance(type, new object[] { 123 });
                    object paraObject1 = Activator.CreateInstance(type, new object[] { "456" });
                    object paraObject2 = Activator.CreateInstance(type, new object[] { 234, "456" });
                    object paraObject3 = Activator.CreateInstance(type, new object[] { "zkang", 456 });
                }
                // 反射调用方法一定要类型转换后才能调用吗？ -- 当然不是

                // 5-2. 反射调用方法
                {
                    // 1. 获取方法 MethodInfo
                    Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll");  // 动态读取 DLL
                    Type type = assembly.GetType("Business.DB.MySql.ReflectionTest"); // 读取类
                    object oInstance = Activator.CreateInstance(type);  // 创建类的实例化对象

                    // 2. 执行MethodInfo的Invoke方法，传递方法所在类的实例对象 + 参数
                    //  a. 调用无参数方法
                    {
                        MethodInfo show1 = type.GetMethod("Show1");     // 获取无参方法
                        show1.Invoke(oInstance, new object[] { });
                        show1.Invoke(oInstance, new object[0] { });
                        show1.Invoke(oInstance, null);
                    }
                    //  b. 调用有参数方法 -- 重载方法 -- 需要通过方法参数类型区分方法，传递参数的时候也需要严格匹配
                    {
                        MethodInfo show2 = type.GetMethod("Show2");     // 获取有参方法
                        // show1.Invoke(oInstance, new object[] { });  // 没有参数会报错：参数个数不匹配
                        show2.Invoke(oInstance, new object[] { 123 });

                        // MethodInfo show3_1 = type.GetMethod("Show3");     // 获取重载方法，报错，找不到匹配
                        MethodInfo show3_1 = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                        show3_1.Invoke(oInstance, new object[] { "zkang", 234 });

                        MethodInfo show3_2 = type.GetMethod("Show3", new Type[] { typeof(int) });
                        show3_2.Invoke(oInstance, new object[] { 345 });

                        MethodInfo show3_3 = type.GetMethod("Show3", new Type[] { typeof(string) });
                        show3_3.Invoke(oInstance, new object[] { "zkang" });

                        MethodInfo show3_4 = type.GetMethod("Show3", new Type[0]);  // 无参类型
                        show3_4.Invoke(oInstance, null);
                    }
                    // c. 获取私有方法，在获取方法的时候，加上参数 BindingFlags.NonPublic | BindingFlags.Instance
                    {
                        // MethodInfo show4 = type.GetMethod("Show4"); // 私有方法这种方式获取不到
                        MethodInfo show4 = type.GetMethod("Show4", BindingFlags.NonPublic | BindingFlags.Instance);
                        show4.Invoke(oInstance, new object[] { "zzzz" });

                    }
                    // d. 获取静态方法
                    {
                        // ReflectionTest.Show5();  // 正常调用静态方法
                        //Assembly assembly1 = Assembly.LoadFrom("Business.DB.MySql.dll");  // 动态读取 DLL
                        //Type type1 = assembly.GetType("Business.DB.MySql.ReflectionTest"); // 读取类
                        MethodInfo show5 = type.GetMethod("Show5");
                        show5.Invoke(null, new object[] { "zzzz" });
                        show5.Invoke(oInstance, new object[] { "zzzz" });
                    }
                    // e. 获取泛型方法：1.获取到方法后， 先确定类型，严格按照参数类型传递参数就可以正常调用。
                    {
                        // 泛型是延迟声明，调用的时候，确定类型
                        Type type1 = assembly.GetType("Business.DB.MySql.GenericMethod"); // 读取类
                        object oInstance1 = Activator.CreateInstance(type1);
                        MethodInfo show = type1.GetMethod("Show");
                        // show.Invoke(oInstance1, );  // 获取泛型类 应该给什么类型呢？泛型，不确定类型。

                        // 在调用Invoke时候确定是什么类型？
                        MethodInfo genericShow = show.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });

                        genericShow.Invoke(oInstance1, new object[] { 123, "ZK", DateTime.Now });
                        // genericShow.Invoke(oInstance1, new object[] { "ZK", 123, DateTime.Now });  // 会报错，需要严格按照参数类型传递参数
                    }

                    // f. 获取泛型类
                    {
                        Type type1 = assembly.GetType("Business.DB.MySql.GenericClass"); // null，这样读取泛型类是读不到的 

                        Console.WriteLine(typeof(GenericClass<,,>));    // 会输出:Business.DB.MySql.GenericClass`3[T,W,X]
                        Type type2 = assembly.GetType("Business.DB.MySql.GenericClass`3");  // 获取到泛型类，
                        // object oInstance2 = Activator.CreateInstance(type2); // 直接调用会报错，泛型方法调用需要 MakeGenericType
                        Type genericType = type2.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                        object oInstance2 = Activator.CreateInstance(genericType);

                        MethodInfo show = genericType.GetMethod("Show");
                        show.Invoke(oInstance2, new object[] { 123, "zk", DateTime.Now });

                    }

                    // g. 获取泛型类 泛型方法
                    {
                        Type type1 = assembly.GetType("Business.DB.MySql.GenericDouble`1"); // 获取类型（类）
                        Type genericType = type1.MakeGenericType(new Type[] { typeof(int) });
                        object oInstance2 = Activator.CreateInstance(genericType);

                        MethodInfo show = genericType.GetMethod("Show");
                        // show.Invoke(oInstance2, new object[] { 123, "zk", DateTime.Now }); // 会报错，因为只获取到了依赖泛型类的第一个参数，剩余连个没参数

                        MethodInfo genericShow = show.MakeGenericMethod(new Type[] { typeof(string), typeof(DateTime) });
                        genericShow.Invoke(oInstance2, new object[] { 123, "ZK", DateTime.Now });
                    }
                }

                #endregion

                #region 6. 反射多种应用场景
                Console.WriteLine("6. 反射多种应用场景");
                {
                    // 1. 反射 + 配置文件 + 工厂  -- 后面要讲的IOC容器 -- IOC容器的雏形；简单版本的IOC容器；
                    // 2. 调用方法 -- 需要类型名称 + 方法名称就可以调用到具体方法； --类型名称（字符串） + 方法名称（字符串）==== 就可以去调用方法  -- 对应最典型的场景就是MVC框架 （例子：WebApp项目）
                    // 3. 创建一个MVC项目 -- http://localhost:5046/Home/Index，在访问此地址的时候就会访问到 HomeController下的Index方法 -- 就需要创建Home的实例； 执行Index方法 -- 这个访问的过程当然是反射来实现的
                }
                #endregion

                #region 7. 反射的局限 --真的有性能问题
                Console.WriteLine("7. 反射的局限 --真的有性能问题");
                {
                    // 1. 有局限 --性能问题，主要损耗性能的是加载 dll 的时候有性能损耗。经过优化在可承受范围之内。
                    // 2. 测试用例： 普通方式循环1000000次创建对象 + 方法调用：50 毫秒；
                    //              反射方式循环1000000次创建对象 + 方法调用：4514 毫秒 --4.9秒
                    // 3. 第二次执行：普通方式：20毫秒；反射方式：5376毫秒；

                    // 4. 确实有性能问题：能优化一下吗？
                    //      可以优化：不需要在循环内每次都动态加载程序集和获取类型，放循环换外缓存起来；每次直接使用加载的dll
                    //      优化后执行时间：普通方式：27毫秒；反射方式：32毫秒；

                    // 使用反射的建议：1.反射确实有性能问题，2.希望理性对待性能问题，性能有损耗就不使用吗？不是，依然要用：因为反射经过优化之后其实性能也没差多少。因为反射能量确实是太多了，大家以后在工作中可以放心使用；

                    // Monitor.Show();
                }
                #endregion

                #region 8. 反射操作属性字段
                Console.WriteLine("8. 反射操作属性字段");

                // 反射调用类的属性和字段  --一个类的内部，除了构造函数、方法 -- 还有其他很多东西：属性字段。
                // 1.普通方式调用属性字段 -- 简单快捷
                // 2.反射操作 --稍微麻烦点
                // 3.反射的妙处在于：“ 让我们的程序更加稳定 ”；
                // 4.如果说People中增加一个属性呢？普通方式就必须修改代码，修改代码就得重新编译发布，整个操作是不稳定的。

                // 6.反射方式在设置值：好像也没啥优势
                // 7.反射取值：不需要修改代码 --代码更加稳定

                // 传统方式使用属性和字段 
                {
                    Console.WriteLine("************* 赋值 ************");
                    People people = new People();
                    people.Id = 123;
                    people.Name = "zkang";
                    people.Age = 28;
                    people.Sex = 1;
                    people.Description = "高级班会员";

                    //People people1 = new People()
                    //{
                    //    Id = 123,
                    //    Name = "zkang",
                    //    Age = 28,
                    //    Description = "高级班会员"
                    //};

                    Console.WriteLine("************* 取值 ************");
                    Console.WriteLine($"people.Id = {people.Id}");
                    Console.WriteLine($"people.Name = {people.Name}");
                    Console.WriteLine($"people.Age = {people.Age}");
                    Console.WriteLine($"people.Age = {people.Sex}");
                    Console.WriteLine($"people.Description = {people.Description}");
                }


                Console.WriteLine("************* 反射方式的赋值和取值 ************");
                // 反射方式如何给属性和字段赋值 取值呢？
                {
                    Type type = typeof(People);
                    object pObject = Activator.CreateInstance(type);
                    // pObject.Id = 234;  // 报错，obj     ect类型没有对应的属性和字段

                    // 反射操作属性
                    {
                        // type.GetProperties(); // 获取的是属性
                        // 逐个属性赋值
                        foreach (var prop in type.GetProperties())
                        {
                            //Console.WriteLine($"prop.Name = {prop.Name}");
                            if (prop.Name.Equals("Id"))
                            {
                                prop.SetValue(pObject, 456);
                            }
                            else if (prop.Name.Equals("Name"))
                            {
                                prop.SetValue(pObject, "陈打包");
                            }
                            else if (prop.Name.Equals("Age"))
                            {
                                prop.SetValue(pObject, 25);
                            }
                            else if (prop.Name.Equals("Sex"))
                            {
                                prop.SetValue(pObject, 25);
                            }
                        }

                        // SetValue: 设置值
                        // GetValue: 获取值
                        // 逐个属性获取值
                        foreach (var prop in type.GetProperties())
                        {
                            Console.WriteLine($"people.{prop.Name} = {prop.GetValue(pObject)} ");
                        }
                    }

                    // 反射操作字段
                    {
                        // type.GetFields();   // 获取的是字段
                        // 逐个属性赋值
                        foreach (var prop in type.GetFields())
                        {
                            //Console.WriteLine($"prop.Name = {prop.Name}");
                            if (prop.Name.Equals("Description"))
                            {
                                prop.SetValue(pObject, "Description");
                            }
                        }
                        // SetValue: 设置值
                        // GetValue: 获取值
                        // 逐个字段获取值
                        foreach (var prop in type.GetFields())
                        {
                            Console.WriteLine($"people.{prop.Name} = {prop.GetValue(pObject)} ");
                        }
                    }
                }


                #endregion

                #region 9. 反射 + ADO.NET实现数据库访问层 --手写ORM框架
                Console.WriteLine("9. 反射 + ADO.NET实现数据库访问层 --手写ORM框架");

                // 1.ORM --对象关系映射
                // 2.可以通过依赖于某个实体对象--做到对数据库中数据的操作
                {
                    MySqlHelper mysql = new MySqlHelper();
                    SysCompany compay = mysql.QuerySysCompany(1);
                    // SysCompany查询数据已完成

                    // ORM框架 -- ORM --可以查询任何类型的数据 --增删改查都可以做到
                    // 1.如果要查询 SysUser 呢？ --可以再写一个SysUser的查询方法呗？ 能行吗？
                    //      要查询的东西何其多？难道每一个数据库中对应的表都来一个方法吗？
                    // 2.特点：查询的时候，是根据不同的实体对象来进行查询 --不同的类型 --能不能一个方法完成？
                    // 3.如果希望一个方法满足不同类型的需求，那就是泛型方法

                    // MySqlHelper mysql = new MySqlHelper();
                    SysCompany compay1 = mysql.Find<SysCompany>(2);
                    SysUser user = mysql.Find<SysUser>(1);
                    SysUser user1 = mysql.Find<SysUser>(1);
                    SysUser user2 = mysql.Find<SysUser>(2);
                    SysUser user3 = mysql.Find<SysUser>(1);
                    SysUser user4 = mysql.Find<SysUser>(3);
                    SysUser user5 = mysql.Find<SysUser>(1);

                    // 反射 + 泛型 == ORM框架（只实现了查询）；
                    // 今天这里只是实现了查询 --增加、修改、删除呢？ 当然也可以实现。
                    //      剩余 增加、修改、删除 自己写。
                }

                #endregion

                #region 10. Emit技术
                Console.WriteLine("10. Emit技术");

                // Emit技术：在运行时动态的生成DLL，exe, 包括dll内部分方法、属性、字段。。。。。
                {
                    Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll");
                    Module[] modules = assembly.GetModules();
                    foreach (var module in modules)
                    {
                        Console.WriteLine(module.Name);
                        foreach (var type in module.GetTypes())
                        {
                            Console.WriteLine(type.Name);
                        }
                    }
                }

                ReflectionEmit.Show();

                // Emit技术：
                // 1. 动态的生成：可以在代码运行的时候去动态的定义业务逻辑；
                // 2. 偏向于底层 --学习成本比较高 --除非是非常复杂的业务逻辑，一般情况下，用的比较少 -- 动态代理的时候，还会再讲；

                #endregion

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}