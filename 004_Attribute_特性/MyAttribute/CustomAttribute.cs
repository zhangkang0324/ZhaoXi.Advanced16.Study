namespace MyAttribute {
    /// <summary>
    /// 直接继承特性
    /// </summary>
    // [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class CustomAttribute : Attribute {

        private int _Id { get; set; }
        private string _Name { get; set; }

        public int _Age;


        public CustomAttribute() {
            Console.WriteLine($"{GetType().Name}无参数构造函数执行");
        }
        public CustomAttribute(int id) {
            Console.WriteLine($"{GetType().Name}int参数构造函数执行");
            _Id = id;
        }
        public CustomAttribute(string name) {
            Console.WriteLine($"{GetType().Name}string参数构造函数执行");
            _Name = name;
        }
        public void Do() {
            Console.WriteLine("this is CustomAttribute");
        }



        public string Remark;
        public string Description { get; set; }
        public void Show() {
            Console.WriteLine($"{_Id}_{_Name}_{Remark}_{Description}");
        }
    }

    /// <summary>
    /// 间接继承特性
    /// </summary>
    internal class CustomAttributeChild : CustomAttribute {
        public CustomAttributeChild() : base(123) {
        }
    }
}
