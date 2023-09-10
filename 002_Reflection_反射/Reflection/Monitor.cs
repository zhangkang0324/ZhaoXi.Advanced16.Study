using Business.DB.Interface;
using Business.DB.MySql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("**************** Monitor ****************");
            long commonTime = 0;
            long reflectionTime = 0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    IDBHelper iDbHelper = new MySqlHelper();
                    iDbHelper.Query();
                }
                watch.Stop();
                commonTime = watch.ElapsedMilliseconds;
            }

            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                // 动态加载
                Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll"); //1.动态加载
                Type dbHelperType = assembly.GetType("Business.DB.MySql.MySqlHelper");  //2.获取类型


                for (int i = 0; i < 1_000_000; i++)
                {
                    //Assembly assembly = Assembly.LoadFrom("Business.DB.MySql.dll"); //1.动态加载， 不需要在循环内每次都动态加载，放循环换外
                    //Type dbHelperType = assembly.GetType("Business.DB.MySql.MySqlHelper");  //2.获取类型，不需要每次都重新获取类型，放循环外

                    // a. 调用无参数构造函数
                    object oDbHelper = Activator.CreateInstance(dbHelperType);  //3.创建对象
                    IDBHelper dbHelper = (IDBHelper)oDbHelper;
                    dbHelper.Query();
                }
                watch.Stop();
                reflectionTime = watch.ElapsedMilliseconds;
            }

            Console.WriteLine($"commonTime = {commonTime} reflectionTime = {reflectionTime}");
        }
    }
}
