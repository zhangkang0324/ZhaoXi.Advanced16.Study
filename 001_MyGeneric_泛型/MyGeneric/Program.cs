using MyGeneric.Extension;

namespace MyGeneric
{
    internal class Program
    {
        /// <summary>
        /// 泛型：
        ///     1. 泛型的引入
        ///     2. 泛型的声明
        ///     3. 泛型的特点 + 原理
        ///     4. 泛型的优势，核心设计
        ///     5. 泛型方法，泛型类
        ///     6. 泛型接口， 泛型委托
        ///     7. 泛型约束，泛型缓存
        ///     8. 协变、逆变
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎来到.Net高级班VIP课程，今天Richard老师讲解泛型 Generic !");

            int iValue = 123;
            string strValue = "456";
            DateTime dtValue = DateTime.Now;
            object objValue = "678";


            #region 一. 泛型的引入
            Console.WriteLine("******** 泛型的引入 ********");

            // 1. 泛型是什么？
            //      -- 泛：宽泛的--不确定的； 型：类型；
            //      泛型就是：不确定的类型；

            // 2. 泛型是无处不在的;

            // 3. 调用普通方法的时候，参数类型在申明的时候就确定了，调用按照类型参数传递参数即可：
            {
                CommonMethod.ShowInt(iValue);
                CommonMethod.ShowString(strValue);
                CommonMethod.ShowDateTime(dtValue);
                Console.WriteLine("***************************");
                CommonMethod.ShowObject(objValue);

                // 👇 此处需要思考以下两个问题： 
                //  a. 如果有100个类型-- 要写100个方法？        -- 很累很繁琐，代码也会有重复；
                //  b. 有没有能够做一个方法可以能够满足不同类型的需求呢？        -- 有，可以使用object替代原有的数据类型.
            }

            // 4. Object类型作为参数 --可以传递不同的类型进去,因为所有的类型都是由object类派生出来的。
            //      a.任何子类出现的地方都可以让父类来代替;
            //      b.万物皆对象-- 任何一个类型都是继承自Object;
            {
                CommonMethod.ShowObject(iValue);
                CommonMethod.ShowObject(strValue);
                CommonMethod.ShowObject(dtValue);

                // 👇 此处需要思考： 这种实现方式会带来哪些问题？  
            }

            // 5. 带来的问题：
            //   a. 性能问题 --造成频繁的装箱和拆箱：在C#语法中，按照声明决定实际数据类型（值类型分配在线程栈中，引用类型分配在托管堆中）；
            //      · 装箱：值类型转换为引用类型：（1、在托管堆中分配内存，分配内存大小是值类型个字段所需的内存大小之和；2、值类型的字段复制到新分配的堆内存；  3、返回对象地址，该地址是对象引用：值类型变成了引用内存；4、该对象一直存在堆内存中，直到被垃圾回收；）
            //      · 拆箱：引用类型转换为之值类型：（获取已装箱的堆内存上对象的各个字段地址，是一个获取指针地址的过程，将该对象从实例复制到值类型中）
            //   b. 类型安全问题 --（在后面五、泛型约束中讲了类型安全问题）
            {
                // 👇 此处需要思考： 有没有既性能好，也能够满足多种类型需求的方法？ 
            }

            // 6. 有没有既性能好，也能够满足多种类型需求的方法？？ --有 就是泛型方法！
            //  a. 声明--多了尖括号 + 占位符T 
            //  b. 调用--也需要多一个尖括号，尖括号中指定的类型要和传递的参数类型一致；
            //  c. 如果可以通过参数推导出类型 --尖括号可以省略；
            {
                Console.WriteLine("***************************");
                CommonMethod.Show(iValue);  // 不允许，如果可以通过参数推导出类型 --尖括号可以省略
                CommonMethod.Show<string>(strValue);
                CommonMethod.Show<DateTime>(dtValue);
                CommonMethod.Show<object>(objValue);

                // 性能监控：
                Monitor.Show();
            }

            // 7. 泛型方法优势：
            //  -- 做到了性能高--可以一个方法满足不同类型的需求；
            //  -- 又让马儿跑，又让马儿不吃草；

            #endregion


            #region 二. 泛型的声明 --设计思想

            Console.WriteLine("******** 泛型的声明 ********");
            {
                //1. 泛型方法：在方法名称后面多了一个尖括号，尖括号中有占位符
                //2. 延迟声明：声明的时候，只是给一个占位符T，T是什么类型？不知道什么类型 --调用的时候，指定你是什么，调用的时候，你说什么就是什么；

                //3. 占位符：T --类型参数 --类型变量
                //4. 类型参数当作方法的参数时候，明确参数类型;
            }

            #endregion


            #region 三. 泛型的特点+原理 --在底层如何支持？

            // 1. 在高级语言中，定义的泛型T，在计算机执行的时候，一定要是一个具体的类型；
            // 2. 在底层是如何支持？ --在底层看到生成的结果是：List`1[T]  Dictionary`2[TKey,TValue]
            // 3. 在底层 --生成了带有 `1 `2 `3 .....
            // 4. 编译器必须要能够支持泛型 --
            // 5. CLR运行时环境也必须要支持泛型
            // 6. 泛型当然是框架的升级，并不是语法糖，而是由框架的升级支持的；
            // 7. 语法糖是编译器提供的便捷功能 --.NetFramework2.0时代支持的

            {
                Console.WriteLine(typeof(List<>));
                Console.WriteLine(typeof(Dictionary<,>));
            }

            #endregion


            #region 四. 泛型的多种应用
            {
                // 1.泛型方法   --可以一个方法满足不同类型的需求


                // 2.泛型接口   --可以一个接口有满足不同类型的需求 --尖括号+占位符
                {
                    GenericInterface<string> sGenericInterface = null;
                    GenericInterface<DateTime> dtGenericInterface = null;
                }

                // 3.泛型类     --可以一个类型满足不同类型的需求 --尖括号+占位符
                {
                    GenericAbstractClass<string> sGenericClass = null;
                    GenericAbstractClass<DateTime> dtGenericClass = null;
                    GenericAbstractClass<int> iGenericClass = null;
                    // sGenericClass、dtGenericClass、iGenericClass 三者是什么关系？  -- 没有任何关系，是三个独立不同的类，并不是同一个类。
                }

                // 4.泛型委托   --可以一个委托满足不同类型的需求 --尖括号+占位符
                {
                    GenericDelegate<string> sGenericDetagate = null;
                    GenericDelegate<DateTime> dtGenericDetagate = null;
                }
            }
            #endregion


            #region 五. 泛型约束 

            // 要有真正的自由，就必须要有约束；开车 --交通规则 --红绿灯
            // 1. Object类型安全问题： --就是代码可能存在隐患，但是编译器检测不到；
            People people = new People()
            {
                Id = 123,
                Name = "zkang"
            };
            GenericConstraint.ShowObject(people);

            Chinese chinese = new Chinese()
            {
                Id = 234,
                Name = "zhang"
            };
            GenericConstraint.ShowObject(chinese);

            Japanese japanese = new Japanese()
            {
                Id = 345,
                Name = "不穿裤子"
            };

            // 👇 思考：此方式可通用吗？  -- 目前不能，以下方式编译器通过但是运行会报错。
            {
                // 传递iValue呢？ -- 不是People 运行会报错。
                // GenericConstraint.ShowObject(iValue);   // 如果有问题，正常的玩法是不让你正常传递参数。但此处编译器没有报错，运行时候才报错，这就是类型安全问题。
            }
            // 👇 思考：如何避免以上这种类型安全问题？


            // 2. 要如何避免类型安全问题？ 
            //      -- 就是使用泛型, 不存在类型安全问题
            {
                GenericConstraint.Show<People>(people);  // 这种方式避开了类型安全问题，但是出现新的问题：传过去的T泛型类型，不保证都有Id和Name属性。
                                                         // 必须得约束传过来的类型都是Prople类型，由此引出泛型约束的概念。
                GenericConstraint.ShowBase<People>(people);   // 利用泛型约束（基类约束）的方式

            }

            // 泛型约束的方式：

            //1. 基类约束
            //  a.就是把类型参数当做People
            //  b.调用---就可以传递Popple或者People的子类型
            //  c.泛型约束：要么不让你进来，如果让你进来，就一定是没有问题
            // 基类约束的实例：
            {
                GenericConstraint.ShowBase<People>(people);
                GenericConstraint.ShowBase<Chinese>(chinese);
                // GenericConstraint.ShowBase<Japanese>(japanese);  //约定了必须是有一个People才能进来,而japanese不是People也没有继承People，所以不能强制转换为People，编译会报错。
            }


            //2. 接口约束：
            //    a.把这个T 当做ISports
            //    b.就只能传递ISports 这个接口或者是实现过这个接口的类
            //    c.就可以增加功能，可以获取新的功能
            // 接口约束的实例：
            {
                //GenericConstraint.ShowInterface<People>(people);
                GenericConstraint.ShowInterface<Chinese>(chinese);
                GenericConstraint.ShowInterface<Japanese>(japanese);
            }

            //3. 引用类型约束
            //   a.就只能传递类型进来
            // 引用类型约束的实例
            {
                GenericConstraint.ShowClass<People>(people);
                GenericConstraint.ShowClass<Chinese>(chinese);
                GenericConstraint.ShowClass<Japanese>(japanese);
                //GenericConstraint.ShowClass<int>(iValue); //因为Int 是结构--值类型，不符合约束所以不能传递。
            }

            //4. 值类型约束
            //   a.就只能传递值类型进来
            // 值类型约束实例
            {
                //GenericConstraint.ShowStruct<People>(people); //应用类型--不行
                //GenericConstraint.ShowStruct<Chinese>(chinese);//应用类型--不行
                //GenericConstraint.ShowStruct<Japanese>(japanese);//应用类型--不行
                GenericConstraint.ShowStruct<int>(iValue); //因为Int  是Struct
                GenericConstraint.ShowStruct<DateTime>(dtValue); //因为DateTime  是Struct
            }

            //5. 无参数构造函数约束
            //  b.必须有一个无参数构造函数才能当做参数传入
            //  没有有参数构造函数约束
            // -- 无参数构造函数约束实例
            {
                GenericConstraint.ShowNew<People>(people);
            }

            // 还有其他约束吗？
            // 6. 枚举约束
            //   a.必须是一个枚举类型才能传入
            //
            {
                // GenericConstraint.ShowEnum<People>(people);
                GenericConstraint.ShowEnum<Enum>(UserType.Normal);
            }

            // 父子级关系约束（也属于是基类约束的范围）
            {
                GenericConstraint.ShowParent<Chinese, People>(chinese, people);
                // GenericConstraint.ShowParent<People, Chinese>(people, chinese);  // 继承关系不对 会报错。
            }

            #endregion


            #region 六、泛型缓存 --泛型类
            // 应用 - 在后面手写ORM的时候会用到。
            {
                // 泛型类是独立的类，给一个类型都会生成一个新的类。
                // 泛型类方法每次调用都是不同的类，都会走构造函数。

                GenericCacheTest.Show();
            }
            #endregion


            #region 七、泛型的协变/逆变

            // 协变/逆变 是一种高级约束，
            // 是为了规避  1.把子类做参数，却把父类当参数传入；
            //             2.把子类做返回值，但返回的时候，却返回了一个父类；
            {
                ContravariantCovariance.Show();
            }

            {
                ICustomerListOut<Animal> customerListOut = new CustomerListOut<Animal>();
                ICustomerListOut<Animal> customerListOut1 = new CustomerListOut<Cat>();
                //左边是Animal  右边是：Cat
                // customerListOut1.Show(new Animal());
                // customerListOut1.Show(new Cat());

                customerListOut1.Get();
            }

            // 听懂 85%左右。

            #endregion

            Console.ReadLine();
        }
    }
}