﻿using System.Diagnostics;

namespace MyGeneric
{
    /// <summary>
    /// 性能对比
    /// </summary>
    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("*************** Monitor *****************");
            {
                int iValue = 12345;
                long commonSecond = 0;  // 普通方法的计时
                long objectSecond = 0;  // object方法计时
                long genericSecond = 0; // 泛型方法计时

                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000_000; i++)
                    {
                        ShowInt(iValue);
                    }
                    watch.Stop();
                    commonSecond = watch.ElapsedMilliseconds;
                }
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000_000; i++)
                    {
                        ShowObject(iValue);
                    }
                    watch.Stop();
                    objectSecond = watch.ElapsedMilliseconds;
                }
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000_000; i++)
                    {
                        Show<int>(iValue);
                    }
                    watch.Stop();
                    genericSecond = watch.ElapsedMilliseconds;
                }
                Console.WriteLine("commonSecond={0},objectSecond={1},genericSecond={2}"
                    , commonSecond, objectSecond, genericSecond);
            }
        }

        #region PrivateMethod
        private static void ShowInt(int iParameter)
        {
            //do nothing
        }
        private static void ShowObject(object oParameter)
        {
            //do nothing
        }
        private static void Show<T>(T tParameter)
        {
            //do nothing
        }
        #endregion

    }
}
