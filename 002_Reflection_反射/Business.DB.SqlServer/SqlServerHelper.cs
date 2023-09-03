using Business.DB.Interface;

namespace Business.DB.SqlServer
{
    public class SqlServerHelper : IDBHelper
    {
        public SqlServerHelper()
        {
            Console.WriteLine($"{this.GetType().Name} 被构造.");
        }
        public void Query()
        {
            Console.WriteLine($"{this.GetType().Name} .Query");
        }
    }
}