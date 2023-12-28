using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    public class CustomAttribute : Attribute
    { 
        private int _Id { get; set; } 
        public string _Name { get; set; } 

        public int _Age;

        //public CustomAttribute()
        //{
        //}

        public CustomAttribute(int id)
        {
            this._Id = id;
        }

        public CustomAttribute(string name)
        {
            this._Name = name;
        }

        public void Do()
        {
            Console.WriteLine("this is  CustomAttribute");
        }
    }

    public class CustomAttributeChild : CustomAttribute
    {
        public CustomAttributeChild() : base(123)
        {

        }
    }
}
