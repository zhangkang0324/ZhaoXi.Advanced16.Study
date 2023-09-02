namespace MyGeneric
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印int值
        /// </summary>
        /// <param name="iParamater"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, parameter = {iParameter.GetType().Name}, type = {iParameter}");
        }

        /// <summary>
        /// 打印string值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, parameter = {sParameter.GetType().Name}, type = {sParameter}");
        }

        /// <summary>
        /// 打印DateTime值
        /// </summary>
        /// <param name="dtParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, parameter = {dtParameter.GetType().Name}, type = {dtParameter}");
        }

        /// <summary>
        /// 打印object值，Object是引用类型
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, parameter = {oParameter.GetType().Name}, type = {oParameter}");
        }


        /// <summary>
        /// 泛型方法（主角登场）
        /// </summary>
        /// <typeparam name="T">类型变量 类型参数</typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, parameter = {tParameter.GetType().Name}, type = {tParameter}");
        }
    }
}
