using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.ValidateExtend
{
    public static class ValidateInvokeManager
    {
        public static ApiResult ValiDate<T>(this T t) where T : class
        {
            //typeof(T)；
            Type type = t.GetType();
            {
                //#region 判断是否为空
                //foreach (PropertyInfo prop in type.GetProperties())
                //{
                //    if (prop.IsDefined(typeof(RequiredAttribute), true))
                //    {
                //        RequiredAttribute attribute = prop.GetCustomAttribute<RequiredAttribute>();
                //        object oValue = prop.GetValue(t);
                //        ApiResult result = attribute.Validate(oValue);
                //        if (result.Success == false)
                //        {
                //            return result;
                //        }
                //    }
                //}
                //#endregion

                //#region 如果要判断长度
                //foreach (PropertyInfo prop in type.GetProperties())
                //{
                //    if (prop.IsDefined(typeof(LengthAttribute), true))
                //    {
                //        LengthAttribute attribute = prop.GetCustomAttribute<LengthAttribute>();
                //        object oValue = prop.GetValue(t);
                //        ApiResult result = attribute.Validate(oValue);
                //        if (result.Success == false)
                //        {
                //            return result;
                //        }
                //    }
                //}
                //#endregion
            }
            { 
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (prop.IsDefined(typeof(AbstractAttribute), true))
                    {
                        object oValue = prop.GetValue(t); 
                        foreach (AbstractAttribute attribute in prop.GetCustomAttributes())
                        {
                            ApiResult apiResult = attribute.Validate(oValue);
                            if (apiResult.Success==false)
                            {
                                return apiResult;
                            }
                        } 
                    }
                }
            }
            //....
             
            //入股还有更多的验证呢？难道每一个验证都这样写一下？
            //抽象父类  特性 继承；

            return new ApiResult() { Success = true };
        }
    }
}
