using CSharp_5._6._7._8._9._10.CSharp8._0;

namespace CSharp_5._6._7._8._9._10
{
    internal class CSharp8Info
    {
        /// <summary>
        ///  C# 8.0版本是面向.Net C# Core的第一个主要版本。一些功能依赖于新的CLR功能，而其他功能依赖于仅在.Net Core中添加的库类型。
        ///  C# 8.0向C#语言添加了以下功能和增强功能。
        ///     1. 默认接口方法
        ///     2. Switch 表达式
        ///     3. 属性模式
        ///     4. 元组模式
        ///     5. 位置模式
        ///     6. Using声明
        ///     7. 静态本地函数
        ///     8. 可处置的ref结构
        ///     9. 可为空引用类型
        ///     10. 异步流
        ///     11. 索引和范围
        ///     12. Null合并赋值
        ///     13. 非托管构造函数
        ///     14. 内插逐字字符串的增强功能
        /// </summary>
        public static void Show()
        {
            // 默认接口方法
            {
                IStudent student = new Student();
                student.GetAge();
                student.GetName();
            }

            // 模式匹配
            // switch表达式
            {
                FormRainbowClassic(Rainbow.Blue);
                FormRainbow(Rainbow.Blue);
                // 属性模式
                ComputeSalesTax(new Address() { State = "WA" }, 20);

                // 元组模式
                string strResult = RockPaperScissors("rock", "paper");

                // 位置模式
                Quadrant quadrant = GetQuadrant(new Point(10, 20));
            }

            // using 申明
            {
                WriteLinesToFile(new List<string>() { "Line1", "Line2", "Line3" });
                WriteLinesToFileNew(new List<string>() { "Line1", "Line2", "Line3" });
            }

            // 静态本地函数 (之前学过本地函数，增加了静态)
            {
                M();
                static int M()
                {
                    int y = 5;
                    int x = 7;
                    return Add(x, y);

                    static int Add(int left, int right) => left + right;
                }
            }

            // 可处置的ref结构
            {
                // 详见C#8 UserStruct结构
            }

            // 可为空的引用类型
            //  在之前的版本中，只要是引用类型，就可以支持为null；
            {
                string? name = "zkang";
                Student? student = null;
            }

            // 异步流
            {
                // GetOldAsyncIntList();
                GetAsyncData().Wait();
            }
            // 异步流可释放 IAsyncDisposable
            {
                GetAsyncDispose().Wait();
            }

            // 索引和范围
            {
                string[] words = new string[] {
                    "The",
                    "quick",
                    "brown",
                    "fox",
                    "jumped",
                    "over",
                    "the",
                    "lazy",
                    "dog"
                };
                string message1 = words[0];   // 取第1个下标
                string message2 = words[1];   // 取第2个下标

                var quickBrownFox = words[1..4];  // 取第1到4个下标

                string message3 = words[^1];
                string message4 = words[^2];

                var lazyDog = words[^2..^0];

                var allWords = words[..]; // 全部
                var firstPhrase = words[..4]; // the - fox
                var lastPhrase = words[6..]; // the\lazy\dog

                // 声明范围
                Range phrase = 1..4;
                var text = words[phrase];  // quick\brown\fox
            }


            // Null 合并赋值,等于null则赋值
            {
                List<int> numbers = null;
                int? i = null;

                numbers ??= new List<int>();
                numbers.Add(i ??= 17);
                numbers.Add(i ??= 20);

                Console.WriteLine(string.Join(" ", numbers));  // output: 17
                Console.WriteLine(i);  // output: 17

                numbers ??= new List<int>() { 123, 234, 345, 456, 567, 678 };
            }

            // 内插字符串增强
            //  之前$必须放在@符号前面， 现在可以不区分顺序了；
            {
                string teacher = "zkang";
                string text = $@"欢迎大家学习，我是{teacher}";

                string text1 = $@"欢迎大家
                                    学习
                                    我是{teacher}";

                string text2 = @$"欢迎大家
                                    学习
                                    我是{teacher}";
            }
        }

        /// <summary>
        /// switch的经典使用方式
        /// </summary>
        /// <param name="colorBand"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Rainbow FormRainbowClassic(Rainbow colorBand)
        {
            switch (colorBand)
            {
                case Rainbow.Red:
                    return Rainbow.Red;
                case Rainbow.Orange:
                    return Rainbow.Orange;
                case Rainbow.Yellow:
                    return Rainbow.Yellow;
                case Rainbow.Green:
                    return Rainbow.Green;
                case Rainbow.Blue:
                    return Rainbow.Blue;
                case Rainbow.Indigo:
                    return Rainbow.Indigo;
                case Rainbow.Violet:
                    return Rainbow.Violet;
                default:
                    throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand));
            }
        }

        /// <summary>
        /// Switch模式
        /// </summary>
        /// <param name="colorBand"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Rainbow FormRainbow(Rainbow colorBand) => colorBand switch
        {
            Rainbow.Red => Rainbow.Red,
            Rainbow.Orange => Rainbow.Orange,
            Rainbow.Yellow => Rainbow.Yellow,
            Rainbow.Green => Rainbow.Green,
            Rainbow.Blue => Rainbow.Blue,
            Rainbow.Indigo => Rainbow.Indigo,
            Rainbow.Violet => Rainbow.Violet,
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand))
        };

        /// <summary>
        /// 属性模式
        /// </summary>
        /// <param name="location"></param>
        /// <param name="salePrice"></param>
        /// <returns></returns>
        public static decimal ComputeSalesTax(Address location, decimal salePrice) => location switch
        {
            { State: "WA" } => salePrice * 0.06M,
            { State: "MN" } => salePrice * 0.75M,
            { State: "MI" } => salePrice * 0.05M,
            _ => throw new ArgumentException(message: "invalid State value")
        };

        /// <summary>
        /// 元组模式
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string RockPaperScissors(string first, string second) => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper coveres rock. Paper wins.",
            ("paper ", "scissors") => "paper is cut by scissors. Scissors wins",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins",
            (_, _) => "tie"
        };

        /// <summary>
        /// 位置模式
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Quadrant GetQuadrant(CSharp8._0.Point point) => point switch
        {
            (0, 0) => Quadrant.One,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
        };

        /// <summary>
        /// using声明  --老版本
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static int WriteLinesToFile(IEnumerable<string> lines)
        {
            using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
            {
                int skippedLines = 0;
                foreach (string line in lines)
                {
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                    else
                    {
                        skippedLines++;
                    }
                }
                return skippedLines;
            }
        }

        /// <summary>
        /// using声明  --新版本
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static int WriteLinesToFileNew(IEnumerable<string> lines)
        {
            using var file = new System.IO.StreamWriter("WriteLines2.txt");
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            return skippedLines;
        }

        /// <summary>
        /// 异步版本：返回迭代器
        ///   之前老版本只能支持同步，新版本支持异步
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> GetOldAsyncIntList()
        {
            for (int i = 0; i < 20; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// 异步流支持
        /// </summary>
        /// <returns></returns>
        public static async IAsyncEnumerable<int> GetNewAsyncIntList()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        /// <summary>
        /// 异步流支持
        /// </summary>
        /// <returns></returns>
        public static async Task GetAsyncData()
        {
            await foreach (var number in GetNewAsyncIntList())
            {
                Console.WriteLine(number); ;
            }
        }

        public static async Task GetAsyncDispose()
        {
            await using (var exampleAsyncDisposable = new ExampleAsyncDisposable())
            {

            }
        }
    }
}
