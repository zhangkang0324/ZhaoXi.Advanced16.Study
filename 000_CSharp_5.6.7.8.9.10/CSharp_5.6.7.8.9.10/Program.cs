namespace CSharp_5._6._7._8._9._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("---------- C# 5/6/7/8/9/10语法解读 ----------");

                Console.WriteLine("========== C#5.0语法 ==========");
                CSharp5Info.Show();

                Console.WriteLine("========== C#6.0语法 ==========");
                CSharp6Info.Show();

                Console.WriteLine("========== C#7.0语法 ==========");
                CSharp7Info.Show();

                Console.WriteLine("========== C#8.0语法 ==========");
                CSharp8Info.Show();

                Console.WriteLine("========== C#9.0语法 ==========");
                CSharp9Info.Show();

                Console.WriteLine("========== C#10.0语法 ==========");
                CSharp10Info.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}