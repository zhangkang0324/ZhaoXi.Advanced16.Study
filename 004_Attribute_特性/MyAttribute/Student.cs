using System;
using System.Collections.Generic;
using System.Text;

namespace MyAttribute {
    /// <summary>
    /// 这是一个Student类
    /// </summary>
    //[Obsolete("请不要使用这个了，请使用什么来代替",true)]//系统
    //[Serializable]//可以序列化和反序列化  --类标记了这个特性以后，就可以做序列化

    [Custom(123)]
    [CustomAttributeChild]
    public class Student {
        [Custom(123)]
        [Custom(123)]
        [Custom(123)]
        public int Id { get; set; }

        [Custom("陈大宝")]
        public string Name { get; set; }

        [Custom(123456, _Age = 17)]
        public string Description;

        /// <summary>
        /// 学习
        /// </summary>
        [Custom("山水", _Name = "456789")]
        public void Study() {
            Console.WriteLine($"这里是{this.Name}跟着Eleven老师学习");
        }

        /// <summary>
        /// 提问
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [return: Custom(123)]
        public string Answer([Custom(456)] string name) {
            return $"This is {name}";
        }
    }
}
