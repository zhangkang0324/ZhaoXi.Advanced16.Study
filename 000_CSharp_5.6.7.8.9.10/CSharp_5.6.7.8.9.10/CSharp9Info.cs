using CSharp_5._6._7._8._9._10.CSharp9._0;

namespace CSharp_5._6._7._8._9._10
{
    public class CSharp9Info
    {
        /// <summary>
        /// C#9.0 随.Net5一起发布。它是面向.Net5版本的任何程序集的默认语言版本。它包含以下新功能和增强功能：
        ///     1. 记录
        ///     2. 仅限init的资源库
        ///     3. 顶级语句
        ///     4. 模式匹配增强功能
        ///     5. 性能和互操作性
        ///     6. 本机大小的整数
        ///     7. 函数指针
        ///     8. 禁止发出localsinit标志
        ///     9. 目标类型的new表达式
        ///     10. static·匿名函数
        ///     11. 目标类型的条件表达式
        ///     12. 协变返回类型
        ///     13. 扩展GetEnumerator 支持foreach函数
        ///     14. lambda表达式
        ///     15. 本地函数的属性
        /// </summary>
        public static void Show()
        {
            #region 记录类型
            // 记录类型
            {
                // 不可变性，初始化之后不可修改。
                Person1 person1 = new Person1("zkang", "金牌讲师");
                Console.WriteLine($"person.FirstName = {person1.FirstName}");
                Console.WriteLine($"person.LastName = {person1.LastName}");

                person1.Deconstruct(out string firstName, out string lastName);
                Console.WriteLine($"person.FirstName = {firstName}");
                Console.WriteLine($"person.LastName = {lastName}");
                // person1.FirstName = "123";  // 不允许重新赋值
                Console.WriteLine("============================================");


                // 不可变性
                Person2 person2 = new Person2()
                {
                    FirstName = "zkang",
                    LastName = "金牌讲师"
                };
                Console.WriteLine($"person.FirstName = {person2.FirstName}");
                Console.WriteLine($"person.LastName = {person2.LastName}");
                // person2.FirstName = "change";    // 不允许重新赋值
                Console.WriteLine("============================================");


                // 可变
                Person3 person3 = new Person3()
                {
                    FirstName = "zkang",
                    LastName = "金牌讲师"
                };
                Console.WriteLine($"person.FirstName = {person2.FirstName}");
                Console.WriteLine($"person.LastName = {person2.LastName}");
                person3.FirstName = "change";
            }

            #endregion

            #region 仅限Init的资源库
            {
                var now = new WeatherObservation
                {
                    RecordedAt = DateTime.Now,
                    TemperatureInCelsius = 20,
                    PressureInMillibars = 998.0m
                };
                // now.TemperatureInCelsius = 18;  // 不允许 -- 必须在初始化的时候赋值，后续不允许修改
            }
            #endregion

            #region 顶级语句
            {
                // 顶级语句 - 不使用Main方法的程序
                // 最明显的案例是控制台直接撸码
                // 只有一行代码执行执行所有操作。借助顶级语句，可使用using 指令和执行操作的一行替换所有样本。
            }
            #endregion

            #region 模式匹配增强功能
            {
                // C#9 包括新的模式匹配改进。
                // 类型模式：与对象匹配特定类型
                // 带圆括号的模式强制或强调模式组合的优先级
                // 联合 and 模式要求两个模式都匹配
                // 析取 or 模式要求任一模式匹配
                // 否定 not 模式要求模式不匹配
                // 关系模式要求输入小于、大于、小于等于或大于等于给定常数。

                bool bResult = Extension.IsLetter('1');
                bool bResult1 = Extension.IsLetterOrSeparator('C');

                string? e = null;
                if (e is not null)
                {
                    //...
                }

            }
            #endregion

            #region 调整和完成功能
            {
                // 还有其他很多功能有助于更高效的编写代码。 在C#9.0中，已知创建对象的类型时，可在new表达式中省略该类型。最常见的用法是在字段声明中；
                List<WeatherObservation> _observation = new();
                WeatherStation station = new() { Location = "Seattle, WA" };
                station.ForecastFor(DateTime.Now.AddDays(2), new());
            }
            #endregion

            #region 静态匿名函数
            {
                Func<int, bool> func = static i => { return true; };
                func.Invoke(123);
            }
            #endregion

            #region 扩展 GetEnumerator 支持foreach循环
            {
                Person[] PersonList = new Person[3] {
                    new ("John", "Smith"),
                    new ("Jim", "Johnson"),
                    new ("Sue", "Rabon")
                };
                People people = new People(PersonList);
                foreach (var person in people)  // 之前的遍历 必须要实现 IEnumerable 接口，现在只要是内部结构，是迭代器，可以通过扩展方法 GetEnumerator 来支持遍历。
                {
                    Console.WriteLine(person);
                }
            }
            #endregion

            #region Lambda 弃元参数
            {
                // C# 9之前
                Func<int, int, int> zero = (a, b) => 0;
                Func<int, int, int> func = delegate (int a, int b) { return 0; };

                // C# 9
                Func<int, int, int> zero1 = (_, _) => 0;
                Func<int, int, int> func2 = delegate (int _, int _) { return 0; };
            }
            #endregion

            #region 扩展分布方法
            {
                User user = new User();
                user.Show("123455");
            }
            #endregion

        }
    }

    public static class Extension
    {
        public static bool IsLetter(this char c) => c is >= 'a' and <= 'Z' or >= 'A' and <= 'Z';
        public static bool IsLetterOrSeparator(this char c) => c is (>= 'a' and <= 'Z') or (>= 'A' and <= 'Z') or '.' or ',';

    }
}
