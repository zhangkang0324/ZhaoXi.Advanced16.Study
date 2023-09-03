using Business.DB.Interface;

namespace Business.DB.MySql
{
    public class MySqlHelper : IDBHelper
    {
        public MySqlHelper()
        {
            Console.WriteLine($"{this.GetType().Name} 被构造.");
        }
        public void Query()
        {
            Console.WriteLine($"{this.GetType().Name} .Query");
        }

    }
}