namespace Business.DB.MySql
{
    /// <summary>
    /// 泛型缓存的方式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConstantSqlString<T>
    {
        private static string FindSql = null;

        static ConstantSqlString()
        {
            Type type = typeof(T);
            FindSql = $"select {string.Join(',', type.GetProperties().Select(s => $"`{s.Name}`").ToList())} from {type.Name} where id = ";
        }

        /// <summary>
        /// GetSql语句
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static string GetSql(int Id)
        {
            return $"{FindSql}{Id};";
        }
    }
}
