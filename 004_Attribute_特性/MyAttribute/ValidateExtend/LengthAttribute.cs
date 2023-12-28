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
    public class LengthAttribute : AbstractAttribute
    {
        public string _ErrorMessage;
        private int _Min;
        private int _Max;

        /// <summary>
        ///
        /// </summary>
        /// <param name="min">最小长度</param>
        /// <param name="max">最大长度</param>
        public LengthAttribute(int min, int max)
        {
            this._Min = min;
            this._Max = max;
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override ApiResult Validate(object value)
        {
            if (value != null)
            {
                if (value.ToString().Length < _Min || value.ToString().Length > _Max)
                {
                    return new ApiResult()
                    {
                        Success = false,
                        ErrorMessage = _ErrorMessage
                    };
                }
                return new ApiResult()
                {
                    Success = true,
                    ErrorMessage = null
                };
            }
            else
            {
                if (_Min == 0)
                {
                    return new ApiResult()
                    {
                        Success = true,
                        ErrorMessage = null
                    };
                }
                else
                {
                    return new ApiResult()
                    {
                        Success = true,
                        ErrorMessage = null
                    };
                }
            }
        }
    }
}
