using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    public static class RemarkAttributeExtension
    {
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum @enum)
        {
            Type type = @enum.GetType();
            string fieldName = @enum.ToString();
            FieldInfo field = type.GetField(fieldName);
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                //RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(UserStateEnum), true); 
                RemarkAttribute attribute = field.GetCustomAttribute<RemarkAttribute>();
                string description = attribute.GetRemark();
                return description;
            }
            return @enum.ToString();
        }
    }
}
