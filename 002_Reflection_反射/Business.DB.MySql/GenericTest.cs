namespace Business.DB.MySql
{
    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="W"></typeparam>
    /// <typeparam name="X"></typeparam>
    public class GenericClass<T, W, X>
    {
        /// <summary>
        /// 普通方法
        /// </summary>
        /// <param name="t"></param>
        /// <param name="w"></param>
        /// <param name="x"></param>
        public void Show(T t, W w, X x)
        {
            Console.WriteLine($"t.type={t.GetType().Name}, w.type={w.GetType().Name}, x.type={x.GetType().Name}");
        }
    }

    /// <summary>
    /// 普通类
    /// </summary>
    public class GenericMethod
    {
        /// <summary>
        /// 泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <typeparam name="X"></typeparam>
        /// <param name="t"></param>
        /// <param name="w"></param>
        /// <param name="x"></param>
        public void Show<T, W, X>(T t, W w, X x)
        {
            Console.WriteLine($"t.type={t.GetType().Name}, w.type={w.GetType().Name}, x.type={x.GetType().Name}");
        }
    }

    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericDouble<T>
    {
        /// <summary>
        /// 泛型方法
        /// </summary>
        /// <typeparam name="W"></typeparam>
        /// <typeparam name="X"></typeparam>
        /// <param name="t"></param>
        /// <param name="w"></param>
        /// <param name="x"></param>
        public void Show<W, X>(T t, W w, X x)
        {
            Console.WriteLine($"t.type={t.GetType().Name}, w.type={w.GetType().Name}, x.type={x.GetType().Name}");
        }
    }

}
