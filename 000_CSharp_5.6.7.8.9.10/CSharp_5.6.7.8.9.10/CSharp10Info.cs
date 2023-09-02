using CSharp_5._6._7._8._9._10.CSharp10._0;
using CSharp_5._6._7._8._9._10.CSharp9._0;
using MyNameSpace;
using System.Reflection;

namespace CSharp_5._6._7._8._9._10
{
    public class CSharp10Info
    {
        /// <summary>
        /// C#10中的新增功能
        ///     1. 记录结构
        ///     2. 结构类型的改进
        ///     3. 内插字符串处理程序
        ///     4. global using 指令
        ///     5. 文件范围的命名空间声明
        ///     6. 扩展属性模式
        ///     7. 对 Lambda表达式的改进
        ///     8. 可使用 const内插字符串
        ///     9. 记录类型可密封 `ToString()
        ///     10. 改进型明确赋值
        ///     11. 在同一析构中可同时进行赋值和声明
        ///     12. 可在方法上使用AsyncMethodBuilder属性
        ///     13. CallerArgumentExpression属性
        ///     14. 增强的#line pragma
        /// </summary>
        public static void Show()
        {

            #region 结构记录类型
            {
                PersonStruct person = new PersonStruct()
                {
                    Age = 36,
                    Gender = Gender.Male,
                    Name = "zkang"
                };
                // person.Age = 40;  // 不允许修改，只能在初始化时候修改

                PersonNewStruct personNewStruct = new PersonNewStruct()
                {
                    Age = 36,
                    Gender = Gender.Male,
                    Name = "zkang"
                };
                personNewStruct.Age = 40;   // 允许修改，记录结构允许修改属性值 
                personNewStruct.Deconstruct(out string name, out int age, out Gender gender);

                Console.WriteLine($"personNewStruct.Name = {name}");
                Console.WriteLine($"personNewStruct.age = {age}");
                Console.WriteLine($"personNewStruct.gender = {gender}");

                // with 表达式：得到一个结构的副本
                {
                    PersonNewStruct personNew = personNewStruct with { Name = "Sunny" };
                    Console.WriteLine($"personNew.Name = {personNew.Name}");
                    Console.WriteLine($"personNewStruct.Gender = {gender}");
                }
            }
            #endregion

            #region 无参数结构构造函数
            {
                PersonInfo01 person = new PersonInfo01();
                Console.WriteLine($"person.Id = {person.Id}");
                Console.WriteLine($"person.Name = {person.Name}");

                PersonInfo02 person2 = new PersonInfo02("zkang");
                Console.WriteLine($"person2.Id = {person2.Id}");
                Console.WriteLine($"person2.Name = {person2.Name}");

                PersonInfo02 personNoCtor = new PersonInfo02();
                Console.WriteLine($"personNoCtor.Id = {personNoCtor.Id}");
                Console.WriteLine($"personNoCtor.Name = {personNoCtor.Name}");

                PersonInfo03 personInfo03 = new PersonInfo03();
                Console.WriteLine($"personInfo03.Id = {personInfo03.Id}");
                Console.WriteLine($"personInfo03.Name = {personInfo03.Name}");

                PersonInfo03 personInfoNew = new PersonInfo03("zkang老师");
                Console.WriteLine($"personInfoNew.Id = {personInfoNew.Id}");
                Console.WriteLine($"personInfoNew.Name = {personInfoNew.Name}");
            }
            #endregion

            #region 全局使用using指令
            {
                // 隐式usings
                // 隐式usings功能会自动在构建的项目类型添加通用的全局using指令。
                // 要启用隐式using，请在.csproj 文件中设置 ImplictUsings 属性；

                // 静态全局using

            }
            #endregion

            #region 文件范围命名空间
            // 去掉大括号， 在当前文件下的class 都归属于当前命名空间;
            {
                Class1 class1 = new Class1();
                Class2 class2 = new Class2();
                Class3 class3 = new Class3();
                Test test = new Test();
            }
            #endregion

            #region 扩展属性模式
            {
                object obj = new CSharp10._0.UserInfo
                {
                    UserId = 123,
                    UserName = "zkang",
                    Age = 29,
                    Address = new CSharp10._0.Address()
                    {
                        City = "WuHan"
                    }
                };

                if (obj is CSharp10._0.UserInfo { Address: { City: "WuHan" } })
                {
                    Console.WriteLine("WuHan");
                }

                if (obj is CSharp10._0.UserInfo { Address: { City: "WuHan" } })
                {
                    Console.WriteLine("WuHan");
                }
            }
            #endregion

            #region Lambda 改进
            {
                // lambda标记特性
                {
                    Action action = () => { };

                    var f1 = [TestAttribute] () => { };
                    var method = f1.GetMethodInfo();
                    TestAttribute attribute = method.GetCustomAttribute<TestAttribute>();
                    attribute.Show();
                }
                // lambda标记特性 静态修饰
                {
                    var f2 = [TestAttribute] static (int x) => x;
                    var method = f2.GetMethodInfo();
                    TestAttribute attribute = method.GetCustomAttribute<TestAttribute>();
                    attribute.Show();
                }
                // Lambda标记特性修饰返回值
                {
                    var f3 = [return: TestAttribute] static (int x) => x;
                    ICustomAttributeProvider provider = f3.GetMethodInfo().ReturnTypeCustomAttributes;
                    object[] attributeArray = provider.GetCustomAttributes(typeof(TestAttribute), true);
                    foreach (TestAttribute attribute in attributeArray)
                    {
                        attribute.Show();
                    }
                }
                // lambda标记特性修饰参数
                {
                    var f4 = ([TestAttribute] int x) => x;
                    ParameterInfo[] prarArray = f4.GetMethodInfo().GetParameters();
                    foreach (var parm in prarArray)
                    {
                        TestAttribute attribute = parm.GetCustomAttribute<TestAttribute>();
                        attribute.Show();
                    }
                }
            }
            #endregion

            #region 常量内插字符串
            {
                const string Language = "C#";
                const string Platform = ".NET";
                const string Version = "10.0";
                const string FullProductName = $"{Platform} - Language: {Language} Version: {Version}";

                Console.WriteLine($"Language: {Language}");
                Console.WriteLine($"Platform: {Platform}");
                Console.WriteLine($"Version: {Version}");
                Console.WriteLine($"FullProductName: {FullProductName}");
            }
            #endregion

            #region 记录类型可密封 `ToString()
            {
                Person person = new Person("richard", "zkang");
                person.ToString();
            }
            #endregion

            #region Lambda 支持关键字修饰
            {
                var f = ref int (ref int x) => ref x;
            }
            #endregion

        }
    }

    public class TestAttribute : Attribute
    {
        public void Show()
        {
            Console.WriteLine($"{this.GetType().FullName} 被构造··");
        }
    }
}
