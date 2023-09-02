using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public interface GenericInterface<T>
    {
        public T Show();
    }

    // T：类型参数一定要为T吗？ 不一定，可以是S、X、Y，不要使用关键字；
    // 尖括号可以有多个类型参数
    public class GenericClass<T, S, X, Zkang>
    {
        public void Show(T t)
        {

        }
    }

    public abstract class GenericAbstractClass<T>
    {
        public void Show(T t)
        {

        }
    }

    // public abstract class ChildClass : GenericAbstractClass<T>  // 为什么不行？ 因为在使用的时候必须是一个确定的类型
    public abstract class ChildClass : GenericAbstractClass<string>
    {
    }

    public abstract class ChildClass1<S> : GenericAbstractClass<S>  // 为什么可以？ 因为使用的是子类实参S
    {
    }

    public class ChildClass2<S>
    {
        public S Show()
        {
            return default(S);
        }

        public S Show2(S s)
        {
            return s;
        }
    }

    public class ChildClass3 : GenericInterface<int>
    {
        public int Show()
        {
            throw new NotImplementedException();
        }
    }

    public delegate void GenericDelegate<T>();
}
