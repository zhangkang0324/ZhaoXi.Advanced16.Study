using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DB.MySql
{
    public class Singleton
    {
        private static Singleton _Singleton = null;

        /// <summary>
        /// 创建对象的时候执行
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Singleton 被构造。");
        }

        /// <summary>
        /// 被CLR 调用，整个进程中 执行且被执行一次
        /// </summary>
        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}
