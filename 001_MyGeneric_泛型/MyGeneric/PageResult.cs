namespace MyGeneric
{
    internal class PageResult<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> DataList { get; set; }
    }
}
