namespace CSharp_5._6._7._8._9._10.CSharp6._0
{
    public class GenericClass<T>
    {
        public void Show(T t)
        {
            Console.WriteLine($"T name is {typeof(T).FullName}");
        }
    }
}
