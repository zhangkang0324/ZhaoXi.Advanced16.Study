using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RemarkAttribute : Attribute
    {
        private string _Description;

        public RemarkAttribute(string decription)
        {
            this._Description = decription;
        }
         
        public string GetRemark()
        {
            return this._Description;
        }


    }
}
