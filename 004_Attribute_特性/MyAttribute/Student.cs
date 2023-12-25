using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute {
    /// <summary>
    /// 注释：这是一个Student类
    /// </summary>
    // [Obsolete("请不要使用这个方法，请使用别的来代替", true)]
    [Obsolete("请不要使用这个方法，请使用别的来代替")]    //影响程序生成
    [Serializable]  // 加上此标记就可以序列化和反序列化，影响程序运行
    [Custom]
    [CustomAttributeChild]
    public class Student {
        [Custom(123)]
        //[Custom(123)]
        //[Custom(123)]
        public int Id { get; set; }
        [Custom("张三")]
        public string? Name { get; set; }

        [Custom(123456, _Age = 17)]
        public string Description { get; set; }


        /// <summary>
        /// 学习
        /// </summary>
        [Custom("山水", _Age = 18)]
        public void Study() {
            Console.WriteLine($"这里是{Name}跟着Eleven老师学习.net");
        }

        public string Answer(string name) {
            return $"This is {name}";
        }
    }
}
