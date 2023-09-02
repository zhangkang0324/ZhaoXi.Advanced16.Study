using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric.Extension
{
    public class GenericCacheTest
    {
        public static void Show()
        {

            //普通缓存
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(DictionaryCache.GetCache<int>()); //GenericCacheInt
                    Thread.Sleep(10);
                    Console.WriteLine(DictionaryCache.GetCache<long>());// GenericCachelong
                    Thread.Sleep(10);
                    Console.WriteLine(DictionaryCache.GetCache<DateTime>());
                    Thread.Sleep(10);
                    Console.WriteLine(DictionaryCache.GetCache<string>());
                    Thread.Sleep(10);
                    Console.WriteLine(DictionaryCache.GetCache<GenericCacheTest>());
                    Thread.Sleep(10);
                }
            }

            //泛型缓存--可以根据不同的类型生成一个新的类的副本；生合二老无数的副本；
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(GenericCache<int>.GetCache()); //GenericCacheInt
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<long>.GetCache());// GenericCachelong
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<DateTime>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<string>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<GenericCacheTest>.GetCache());
                    Thread.Sleep(10);
                }
            }
        }
    }

    /// <summary>
    /// 字典缓存：静态属性常驻内存
    /// </summary>
    public class DictionaryCache
    {
        private static Dictionary<Type, string> _TypeTimeDictionary = null;

        //静态构造函数在整个进程中，执行且只执行一次；
        static DictionaryCache()
        {
            Console.WriteLine("This is DictionaryCache 静态构造函数");
            _TypeTimeDictionary = new Dictionary<Type, string>();
        }
        public static string GetCache<T>()
        {
            Type type = typeof(T);
            if (!_TypeTimeDictionary.ContainsKey(type))
            {
                _TypeTimeDictionary[type] = $"{typeof(T).FullName}_{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}";
            }
            return _TypeTimeDictionary[type];
        }
    }


    /// <summary>
    ///泛型缓存：
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCache<T>
    {
        static GenericCache()
        {
            Console.WriteLine("This is GenericCache 静态构造函数");
            //_TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff")); 
            _TypeTime = $"{typeof(T).FullName}_{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}";
        }

        private static string _TypeTime = "";

        public static string GetCache()
        {
            return _TypeTime;
        }

    }
}
