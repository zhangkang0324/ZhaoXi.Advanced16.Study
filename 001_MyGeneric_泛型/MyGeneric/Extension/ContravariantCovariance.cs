﻿namespace MyGeneric.Extension
{
    /// <summary> 
    /// out 协变covariant    修饰返回值 
    /// in  逆变contravariant  修饰传入参数
    /// </summary>
    public class ContravariantCovariance
    {
        public delegate T delegateTest<T>(T t);

        /// <summary>
        /// 协变逆变  只针对于泛型接口和泛型委托的 
        /// </summary>
        public static void Show()
        {
            {
                Animal animal1 = null;
                animal1 = new Animal();  // Animal类实例化

                Cat cat1 = null;
                cat1 = new Cat();       // Cat类实例化

                //任何子类都可以使用父类来声明，父类可以声明子类
                Animal animal2 = null;
                animal2 = new Cat();    // 使用Animal声明Cat，Cat是Animal

                // 会报错，猫是动物，但动物不是猫，子类不能声明父类
                // Cat cat2 = null;
                // cat2 = new Animal(); // 不一定，白马非马的故事
                Cat cat2 = null;
                cat2 = (Cat)(new Animal());  // 可能有类型安全问题
            }

            {
                // 一群动物是一群动物
                List<Animal> animalList1 = null;
                animalList1 = new List<Animal>();

                // 一只猫是一个动物
                // 会报错：一堆猫 却不是一堆动物 ---从口语上来说，有点不符合人类的思维逻辑；
                {
                    // List<Animal> animalList2 = null; //--- List<Animal> 针对于Animal的类
                    // animalList2 = new List<Cat>();   //--- List<Cat>针对于Cat的类
                }

                // Why？ ---二者没有父子级关系；当然不能替换； 这是C#语法所决定的。
                // 以上问题说明：泛型存在不友好，不协调的地方！

                // 泛型类不能在左边用父类，这就引入了协变 和 逆变。
                List<Animal> animalList3 = new List<Cat>().Select(c => (Animal)c).ToList();
            }

            // 协变和逆变
            // 协变
            {
                // IEnumerable 也经常把他当成一个集合来用，支持协变
                // 协变：可以让右边用子类，能让左边用父类
                // out：修饰类型参数；就可以让右边用子类，能让左边用父类。一堆猫可以是一堆动物。
                IEnumerable<Animal> animalList1 = new List<Animal>();
                IEnumerable<Animal> animalList2 = new List<Cat>();
                Func<Animal> func = new Func<Cat>(() => null);

                // 协变：Out 类型参数只能做返回值 ，不能做参数 
                ICustomerListOut<Animal> customerList1 = new CustomerListOut<Animal>();
                ICustomerListOut<Animal> customerList2 = new CustomerListOut<Cat>();  //协变 
                // customerList2.Show(new Animal());  
                // customerList2.Show(new Cat());
            }

            // 逆变
            {
                // 逆变: In类型参数只能做参数 ，不能做返回值  
                // 逆变：就可以让右边用父类；左边用子类
                ICustomerListIn<Cat> customerList2 = new CustomerListIn<Cat>();
                ICustomerListIn<Cat> customerList1 = new CustomerListIn<Animal>();
                // 逆变： In 类型参数只能做参数 ，不能做返回值  
                // customerList1.Get();//调用的是接口的方法 
                // customerList1.Get();  //返回的一定是一个Cat 或者是Cat 的子类；
                // 因为通过接口在调用方法的时候只能返回一个Cat,
            }

            //协变逆变的存在，就是为了满足常规场景添加一个避开风险的约束； 
            {
                IMyList<Cat, Animal> myList1 = new MyList<Cat, Animal>();
                IMyList<Cat, Animal> myList2 = new MyList<Cat, Cat>();      // 协变 
                IMyList<Cat, Animal> myList3 = new MyList<Animal, Animal>();// 逆变 
                IMyList<Cat, Animal> myList4 = new MyList<Animal, Cat>();   // 协变+逆变
            }

            //为什么呢？
            //如果没有协变逆变，会如何？
            {
                // 会出现：1、把子类做参数，却把父类当作参数传入；
                       // 2、把子类做返回值，但在返回的时候却返回了一个父类；
            }
        }
    }

    public class Test : ICustomerListOut<Animal>
    {
        public Animal Get()
        {
            return new Cat();
        }

        public void Show(Animal t)
        {

        }
    }

    public class Test2 : ICustomerListOut<Cat>
    {
        public Cat Get()
        {
            throw new NotImplementedException();
        }

        public void Show(Cat t)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 动物
    /// </summary>
    public class Animal
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Cat 猫
    /// </summary>
    public class Cat : Animal
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// T 就只能做参数  不能做返回值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListIn<in T>
    {
        //T Get();

        void Show(T t);
    }

    public class CustomerListIn<T> : ICustomerListIn<T>
    {
        //public T Get()
        //{
        //    return default(T);
        //}

        public void Show(T t)
        {

        }
    }

    /// <summary>
    /// out 协变 只能是返回结果。 无论是Out还是in 也是一种高级约束，避免出现问题.
    /// 泛型T 就只能做返回值； 不能做参数； 
    /// </summary>
    /// <typeparam name="T"></typeparam>

    // public interface ICustomerListOut<T>
    public interface ICustomerListOut<out T>
    {
        T Get();

        // void Show(T t);  // 因为有out修饰符 协变，不能作为参数传递。
    }

    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }

        public void Show(T t)  //t 是Cat的时候，这会儿你给我传递了一个Animal进来。 子类做参数，但是传递了一个父类进来
        {

        }
    }

    public interface IMyList<in inT, out outT>
    {
        void Show(inT t); // 逆变 只能当参数 不能返回
        outT Get();     // 协变 不能当参数 只能返回
        outT Do(inT t); // 协变 逆变 混合 
    }

    /// <summary>
    /// out 协变 只能是返回结果 
    /// in  逆变 只能是参数 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>

    public class MyList<T1, T2> : IMyList<T1, T2>
    {
        public void Show(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
        }

        public T2 Get()
        {
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }

        public T2 Do(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }
    }
}
