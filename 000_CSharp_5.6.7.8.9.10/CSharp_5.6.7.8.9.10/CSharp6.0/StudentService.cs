namespace CSharp_5._6._7._8._9._10.CSharp6._0
{
    public class StudentService
    {
        public StudentService() { }
        public static int Id { get; set; } = 12345678;
        public static string? Name { get; set; }

        public static void StudyStatic()
        {
            Console.WriteLine("this is static method.");
        }

        public static void ShowExceptionType()
        {
            Console.WriteLine("`开始抛出异常`");
            //throw new Exception("001");
            throw new Exception("002");
        }
    }
}
