using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.ValidateExtend
{
    public abstract class AbstractAttribute : Attribute
    {
        public abstract ApiResult Validate(object oValue);
    }
}
