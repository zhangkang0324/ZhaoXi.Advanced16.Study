using System;
using System.Collections.Generic;
using System.Text;

namespace MyAttribute {
    public class StudentVip : Student {
        public string VipGroup { get; set; }

        public void Homework() {
            Console.WriteLine("完成作业联系");
        }

        public long Salary { get; set; }

        public long QQ { get; set; }
    }
}
