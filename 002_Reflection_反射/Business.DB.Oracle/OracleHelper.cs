﻿using Business.DB.Interface;

namespace Business.DB.Oracle
{
    public class OracleHelper : IDBHelper
    {
        public OracleHelper()
        {
            Console.WriteLine($"{this.GetType().Name} 被构造.");
        }
        public void Query()
        {
            Console.WriteLine($"{this.GetType().Name} .Query");
        }
    }
}