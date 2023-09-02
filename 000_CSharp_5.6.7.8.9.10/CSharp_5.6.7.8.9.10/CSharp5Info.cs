using CSharp_5._6._7._8._9._10.CSharp5._0;
using System.Runtime.CompilerServices;

namespace CSharp_5._6._7._8._9._10
{
    internal class CSharp5Info
    {
        /// <summary>
        /// C# 5.0 版本:
        /// C# 5.0 随着Visual Studio2012一起发布，是该语言有针对的一个版本。对此版本中所做的所有工作都归入另一个突破性语言概念.
        ///     1. 异步成员
        ///     2. 调用方信息特性
        /// </summary>
        public static async void Show()
        {
            #region 异步成员
            {
                // async await 相关内容；（在5.0之前不支持async和await）
                UserInfo userInfo = new UserInfo();
                userInfo.Show();                // C#5之前的调用方式
                await userInfo.ShowAsync();     // C#5之后支持async和await后的调用方式
            }
            #endregion

            #region 调用方信息特性
            {
                // 调用方信息特性；（可以方便的查看调用此方法的方法、类 和 代码行数）
                new CSharp5Info().DoProcessing();

                new CSharp5Info().DoProcessingNew();
            }
            #endregion

        }

        public void DoProcessing()
        {
            TraceMessage("Something happend. DoProcessing");
        }
        public void DoProcessingNew()
        {
            TraceMessage("Something happend. DoProcessingNew");
        }

        public void TraceMessage(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int souceLineNumber = 0)
        {
            Console.WriteLine("message：" + message);
            Console.WriteLine("member Name：" + memberName);
            Console.WriteLine("source File Path：" + sourceFilePath);
            Console.WriteLine("souce Line Number：" + souceLineNumber);

            // 调用此方法，是哪个类中哪个方法中的第几行代码来调用本方法；
        }
    }
}
