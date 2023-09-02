namespace CSharp_5._6._7._8._9._10
{
    internal class CSharp7Info
    {
        /// <summary>
        /// C#7.0已经与Visual Studio 2017一起发布。虽然该版本继承和发展了C#6.0，但不包含编译器和服务。
        ///     1. out变量
        ///     2. 元组和析构函数
        ///     3. 模式匹配
        ///     4. 本地函数
        ///     5. Ref局部变量和返回结果
        /// </summary>
        public static void Show()
        {
            #region out变量
            // Out变量：
            {
                Console.WriteLine("    ---------- Out变量 ----------    ");
                var input = "123456";
                if (int.TryParse(input, out var result))
                {
                    Console.WriteLine($"您输入的数字是：{result}");
                }
                else
                {
                    Console.WriteLine("无法解析输入内容。。");
                }
            }
            #endregion

            #region 元组和析构函数

            // 元组
            // 元组简单化
            {
                Console.WriteLine("    ---------- 元组简单化 ----------    ");
                Tuple<double, int> text = new Tuple<double, int>(123, 345);  // 正常用法
                // text.Item1
                // text.Item2
                (double, int) t1 = (4.5, 3);    // 简单用法
                Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}");

                (double Sum, int Count) t2 = (4.5, 3);    // 简单用法
                Console.WriteLine($"Tuple with elements {t2.Count} and {t2.Sum}");
            }

            // 元组的用例
            {
                Console.WriteLine("    ---------- 元组的用例 ----------    ");
                var xs = new[] { 1, 2, 3 };
                var limits = FindMinMax(xs);
                Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");

                var ys = new[] { -9, 0, 67, 100 };
                var (minimum, maximum) = FindMinMax(ys);
                Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
            }

            // 元组字段名称
            {
                Console.WriteLine("    ---------- 元组字段名称 ----------    ");
                var t = (Sum: 4.5, Count: 3);
                Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");

                (double Sum, int Count) d = (4.5, 3);
                Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");
            }

            // 元组取值
            {
                Console.WriteLine("    ---------- 元组取值 ----------    ");
                var a = 1;
                var t = (a, b: 2, 3);
                Console.WriteLine($"The 1st element is {t.Item1} (same as {t.a})");
                Console.WriteLine($"The 2nd element is {t.Item2} (same as {t.b})");
                Console.WriteLine($"The 3rd element is {t.Item3}");
            }

            // 元组赋值
            {
                Console.WriteLine("    ---------- 元组赋值 ----------    ");
                (int, double) t1 = (17, 3.14);
                (double First, double Second) t2 = (0.0, 1.0);
                t2 = t1;
                Console.WriteLine($"{nameof(t2)} :{t2.First} and {t2.Second} .");

                (double A, double B) t3 = (2.0, 3.0);
                t3 = t2;
                Console.WriteLine($"{nameof(t3)} :{t3.A} and {t3.B} .");
            }

            // 元组在括号内显式声明每个变量的类型
            {
                Console.WriteLine("    ---------- 元组在括号内显式声明每个变量的类型 ----------    ");
                var t = ("post office", 3.6);
                (string destination, double distance) = t;
                Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            }

            // 元组在括号外使用var关键字来声明隐式类型化变量，并让编译器推断其类型；
            {
                Console.WriteLine("    ---------- 元组在括号外使用var关键字来声明隐式类型化变量 ----------    ");
                var t = ("post office", 3.6);
                var (destination, distance) = t;
                Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            }

            // 元组使用现有变量
            {
                Console.WriteLine("    ---------- 元组使用现有变量 ----------    ");
                var destination = string.Empty;
                var distance = 0.0;
                var t = ("post office", 3.6);
                (destination, distance) = t;
                Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            }

            // 元组元组相等
            {
                Console.WriteLine("    ---------- 元组元组相等 ----------    ");
                (int a, byte b) left = (5, 10);
                (int a, byte b) right = (5, 10);
                Console.WriteLine(left == right);
                Console.WriteLine(left != right);

                var t1 = (A: 5, B: 10);
                var t2 = (B: 5, A: 10);
                Console.WriteLine(t1 == t2);    // True
                Console.WriteLine(t1 != t2);    // False
            }

            // 元组作为out参数
            {
                Console.WriteLine("    ---------- 元组作为out参数 ----------    ");
                var limitsLookup = new Dictionary<int, (int Min, int Max)>()
                {
                    [2] = (4, 10),
                    [4] = (10, 20),
                    [6] = (0, 23)
                };

                if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
                {
                    Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
                }
            }
            #endregion

            #region 模式匹配

            //  模式匹配
            Console.WriteLine("    ---------- 模式匹配 ----------    ");
            // Null检查
            {
                Console.WriteLine("    ---------- Null检查 ----------    ");
                int? maybe = 12;
                if (maybe is int number)
                {
                    Console.WriteLine($"The nullable int 'maybe' has the value {number} .");
                }
                else
                {
                    Console.WriteLine($"The nullable int 'maybe' doesn't hold a value.");
                }

                string? message = "This is not the null string.";
                if (message is not null)
                {
                    Console.WriteLine(message);
                }
            }

            // 类型测试
            {
                int intResult = MidPoint(new List<int> { 123, 234, 345, 456 });

                List<int> para = null;
                //int nullResult = MidPoint(para);
            }

            // 比较离散值
            {
                string sResult1 = PerformOperation("SystemTest");
                string sResult2 = PerformOperation("Start");
                string sResult3 = PerformOperation("Stop");
                string sResult4 = PerformOperation("Reset");
                // string sResult5 = PerformOperation("1234545");
            }

            // 关系模式
            {
                string sResult = WaterState(33);
                string sResult2 = WaterState(30);
                string sResult3 = WaterState(333);
            }

            #endregion

            #region 本地函数

            // 本地函数
            {
                SayHello("你好`");
                string SayHello(string hello)
                {
                    Console.WriteLine(hello);
                    return hello;
                }
            }

            // 弃元
            {
                var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
                Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:No}");
            }

            // 命名参数
            {
                QueryCityDataForYears(year1: 2022, year2: 2021, name: "Richard");
            }

            // 默认参数，多个参数，给了默认值，可以只传递部分参数，如果传递给带有默认值的参数数据，以传入为准
            {
                ExampleMethod(123, "", 0);
                ExampleMethod(123456);
            }

            #endregion

            #region Ref局部变量和返回结果

            // Ref局部变量和返回结果
            {
                int[] a = { 0, 1, 2, 3, 4, 5 };
                // x 不是一个引用，函数将值赋值给左侧变量x
                int x = GetLast(a);
                Console.WriteLine("=====================================================");
                Console.WriteLine($"x: {x}, a[2]: {a[a.Length - 1]}");
                x = 99;
                Console.WriteLine("=====================================================");
                Console.WriteLine($"x: {x}, a[2]: {a[a.Length - 1]} \n");

                // 返回引用，需要使用ref关键字，y是一个引用，指向a[a.length-1]
                ref int y = ref GetLast(a);
                Console.WriteLine("=====================================================");
                Console.WriteLine($"y: {y}, a[2]: {a[a.Length - 1]} \n");
            }
        }

        #endregion


        public static (int min, int max) FindMinMax(int[] input)
        {
            if (input is null || input.Length == 0)
            {
                throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
            }
            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var i in input)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            return (min, max);
        }

        public static T MidPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list)
            {
                return list[list.Count / 2];
            }
            else if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
            }
            else
            {
                int halfLength = sequence.Count() / 2 - 1;
                if (halfLength < 0) halfLength = 0;
                return sequence.Skip(halfLength).First();
            }
        }

        public static string PerformOperation(string command) => command switch
        {
            "SystemTest" => "SystemTest",
            "Start" => "Start",
            "Stop" => "Stop",
            "Reset" => "Reset",
            _ => throw new ArgumentException("Invalid string value for command", nameof(command))
        };

        public static string WaterState(int tempInfahrenheit) => tempInfahrenheit switch
        {
            (> 32) and (< 212) => "liquid",
            < 32 => "solid",
            > 212 => "gas",
            32 => "solid/liquid transition",
            212 => "liquid / gas transition",
        };

        public static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.68;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }

        /// <summary>
        /// 默认参数
        /// </summary>
        /// <param name="required"></param>
        /// <param name="optionalstr"></param>
        /// <param name="optionalint"></param>
        public static void ExampleMethod(int required, string optionalstr = "default string", int optionalint = 10)
        {

        }

        /// <summary>
        /// Ref
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ref int GetLast(int[] a)
        {
            if (a == null || a.Length < 1)
            {
                throw new Exception("数组为空.");
            }

            int number = 18;

            // 错误声明：引用声明和初始化分开是错误的
            // ref int n1;
            // n1 = number;

            // 正确声明：声明引用时必须初始化，声明和初始化在一起
            // 添加关键字ref表示n1是一个引用，
            ref int n1 = ref number;

            //n1指向number，不论修改n1或number，对双方都有影响，相当于双方绑定了。
            n1 = 19;
            Console.WriteLine($"n1:{n1}, number:{number}");
            number = 20;
            Console.WriteLine($"n1:{n1}, number:{number}");

            // 语法正确，但本质是将a[2]的值赋值给n1引用所指，n1仍指向number，如果需要指向别的变量 需要在赋值号（=）之后加上ref
            n1 = a[2];
            Console.WriteLine($"n1:{n1}, number:{number}, a[2]:{a[2]}");
            number = 21;
            Console.WriteLine($"n1:{n1}, number:{number}, a[2]:{a[2]}");

            // -------------------------引用返回------------------------
            // return ref n1

            // 正确：n2引用a[2], a[2]生存期不仅仅限于方法内，所以可以返回。
            ref int n2 = ref a[a.Length - 1];
            return ref n2;  // 需要ref返回一个引用
            // return ref a[a.length-1];    // 也可以直接返回一个引用
        }
    }
}
