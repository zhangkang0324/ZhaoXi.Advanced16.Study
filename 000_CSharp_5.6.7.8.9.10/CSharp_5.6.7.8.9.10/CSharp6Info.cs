//using CSharp_5._6._7._8._9._10.CSharp6; // 正常的引入
using static CSharp_5._6._7._8._9._10.CSharp6._0.Color;             // 引入枚举
using static CSharp_5._6._7._8._9._10.CSharp6._0.StudentService;    // 引入带有静态成员的类

using sharp5 = CSharp_5._6._7._8._9._10.CSharp5;     // 给命名空间起一个别名
using Sharp6genericeInt = CSharp_5._6._7._8._9._10.CSharp6._0.GenericClass<int>;
using Sharp6genericeString = CSharp_5._6._7._8._9._10.CSharp6._0.GenericClass<string>;
using Sharp6genericeDateTime = CSharp_5._6._7._8._9._10.CSharp6._0.GenericClass<System.DateTime>;

namespace CSharp_5._6._7._8._9._10
{
    internal class CSharp6Info
    {
        /// <summary>
        /// C#在3.0和5.0版对面向对象的语言添加了主要的新功能。 版本 6.0 随着Visual Studio 2015 一起发布。
        /// 该版本没有推出主导性的功能，只是增加了一些提高效率的小功能。如下：
        /// 1. 静态导入using
        /// 2. 异常筛选器
        /// 3. 自动属性初始化表达式
        /// 4. Expression bodied成员
        /// 5. Null传播器
        /// 6. nameof 运算符
        /// </summary>
        public static void Show()
        {
            #region 静态导入Using
            // 静态导入
            {
                //StudentService.StudyStatic();  // 静态类通用的调用方式
                StudyStatic();  // 来自StudentService的静态方法
                                //Id = 23;
                Name = "这里是静态字段";

                Console.WriteLine($"Id = {Id}");
                Console.WriteLine($"Name = {Name}");

                var red = Red;
                var green = Green;
                var blue = Blue;
                Console.WriteLine($"枚举 Color.Red = {red}");
                Console.WriteLine($"枚举 Color.Green = {green}");
                Console.WriteLine($"枚举 Color.Blue = {blue}");
            }

            // using 别名
            {
                Console.WriteLine("======== C#6版本 using 别名 ============");
                MyCompany.Project.MyClass myclass = new MyCompany.Project.MyClass();

                sharp5._0.UserInfo userInfo = new sharp5._0.UserInfo();

                Console.WriteLine("======== C#6版本 using 泛型类别名 ============");
                Sharp6genericeInt genericIntClass = new Sharp6genericeInt();
                genericIntClass.Show(123456);

                Sharp6genericeString genericStringClass = new Sharp6genericeString();
                genericStringClass.Show("您好，这里是Charp6的Using别名");

                Sharp6genericeDateTime genericDateTimeClass = new Sharp6genericeDateTime();
                genericDateTimeClass.Show(DateTime.Now);
            }
            #endregion

            #region 异常筛选器
            // 异常捕捉筛选
            {
                try
                {
                    //ShowExceptionType();
                }
                catch (Exception e) when (e.Message.Contains("002"))
                {
                    Console.WriteLine("这里是处理捕捉到的002的异常`");
                }
            }
            #endregion

            #region 自动属性初始化表达式
            // 自动属性初始化表达式 和 expression-bodied成员
            {
                Console.WriteLine(Id);

                // expression-bodied成员 =>
                sharp5._0.UserInfo user = new sharp5._0.UserInfo();
                user.Name = "zkang";
                string userName = user.GetUserName();
                Console.WriteLine(userName);
            }
            #endregion

            #region Expression bodied成员
            // NULL条件运算符 ?. 和 ?[]
            {
                sharp5._0.UserInfo? user1 = null;  // 如果这个user1为null，user1.Name 会报错：未将对象引用到对象的实例

                //if (User1 !== null)
                //{
                //    // 判断不为null 则处理对应的代码
                //}
                var userName = user1?.Name;  // 不为null则赋值，为null则返回null
                Console.WriteLine("userName 为" + userName);

                user1 = new sharp5._0.UserInfo
                {
                    Name = "张三"
                };
                var userName2 = user1?.Name;
                Console.WriteLine("userName 为" + userName2);
            }
            #endregion

            #region Null传播器
            // 字符串插值  -- $
            {
                string text = "欢迎来到学习课堂！";
                string hello = String.Format("你好, {0}", text);
                Console.WriteLine(hello);
                string hello1 = $"你好:{text}";
                Console.WriteLine(hello1);
            }
            #endregion

            #region nameof 运算符
            // nameof 表达式：用于获取并返回某一个类的名称
            {
                Console.WriteLine(nameof(System.Collections.Generic));
                Console.WriteLine(nameof(List<int>));
                Console.WriteLine(nameof(List<int>.Count));
                Console.WriteLine(nameof(List<int>.Add));

                var numbers = new List<int> { 1, 2, 3 };
                Console.WriteLine(nameof(numbers));
                Console.WriteLine(nameof(numbers.Count));
                Console.WriteLine(nameof(numbers.Add));
            }

            #endregion


        }
    }
}

namespace MyCompany
{
    namespace Project
    {
        public class MyClass
        {

        }
    }
}