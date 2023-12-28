using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.ValidateExtend
{
    /// <summary>
    /// 判断不能为空
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : AbstractAttribute
    {
        public string _ErrorMessage;
        public RequiredAttribute(string message)
        {
            this._ErrorMessage = message;
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override ApiResult Validate(object value)
        {
            //if (string.IsNullOrWhiteSpace(value)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //} 
            bool bResult = value != null && !string.IsNullOrWhiteSpace(value.ToString());
            if (bResult)
            {
                return new ApiResult()
                {
                    Success = bResult
                };
            }
            else
            {
                return new ApiResult()
                {
                    Success = bResult,
                    ErrorMessage = _ErrorMessage
                };
            }

        }
    }
}
