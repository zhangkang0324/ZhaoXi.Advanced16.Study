using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric.Extension
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
                animal1 = new Animal();

                Cat cat1 = null;
                cat1 = new Cat();

                //任何子类都可以使用父类来声明
                Animal animal2 = null;
                animal2 = new Cat();

                ///不一定-- 动物不一定是猫
                //Cat cat2 = null;
                //cat2 = new Animal();

                //Cat cat2 = null;
                //cat2 = (Cat)(new Animal());
            }

            {
                List<Animal> animalList1 = null;
                animalList1 = new List<Animal>();

                //一只猫是一个动物
                //一堆猫 却不是一堆动物---从口语上来说，有点不符合人类的思维逻辑；

                //Why？---二者没有父子级关系；当然不能替换； 这是C#语法所决定的
                //泛型存在不友好，不协调的地方；

                //不能在左边用父类；
                //List<Animal> animalList2 = null; //--- List<Animal> 针对于Animal的类
                //animalList2 = new List<Cat>();   //--- List<Cat>针对于Cat的类 
                // List<Animal> animalList3 = new List<Cat>().Select(c => (Animal)c).ToList();
            }

            //就引入了协变和逆变
            {
                //IEnumerable 也经常把他当成一个集合来用
                //协变  就可以让右边用子类，能让左边用父类
                //out:修饰类型参数；就可以让右边用子类，能让左边用父类
                IEnumerable<Animal> animalList1 = new List<Animal>();
                IEnumerable<Animal> animalList2 = new List<Cat>();
                Func<Animal> func = new Func<Cat>(() => null);

                //协变： Out 类型参数只能做返回值 ，不能做参数 
                ICustomerListOut<Animal> customerList1 = new CustomerListOut<Animal>();
                ICustomerListOut<Animal> customerList2 = new CustomerListOut<Cat>();  //协变 
                                                                                      //customerList2.Show(new Animal());  
                                                                                      //customerList2.Show(new Cat());
            }
            {//逆变 In  只能做参数 ，不能做返回值  
                //逆变：就可以让右边用父类；左边用子类
                ICustomerListIn<Cat> customerList2 = new CustomerListIn<Cat>();
                ICustomerListIn<Cat> customerList1 = new CustomerListIn<Animal>();
                //逆变： In 类型参数只能做参数 ，不能做返回值  
                //customerList1.Get();//调用的是接口的方法 
                //customerList1.Get();  //返回的一定是一个Cat 或者是Cat 的子类；
                //因为通过接口在调用方法的时候只能返回一个Cat,
            }

            //协变逆变的存在，就是为了满足常规场景添加一个避开风险的约束； 
            {
                IMyList<Cat, Animal> myList1 = new MyList<Cat, Animal>();
                IMyList<Cat, Animal> myList2 = new MyList<Cat, Cat>();//协变 
                IMyList<Cat, Animal> myList3 = new MyList<Animal, Animal>();//逆变 
                IMyList<Cat, Animal> myList4 = new MyList<Animal, Cat>();//协变+逆变
            }

            //为什么呢？
            //如果没有协变逆变；会如何？
            {

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
    /// out 协变 只能是返回结果 ，还是int 也是一种高级约束，避免出现问题
    /// 泛型T 就只能做返回值； 不能做参数； 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T>
    {
        T Get();

        //void Show(T t);
    }

    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }

        public void Show(T t)  //t 是Cat的时候，这会儿你给我传递了一个Animal进来，子类做参数，但是传递了一个父类简历
        {

        }
    }

    public interface IMyList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);
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
