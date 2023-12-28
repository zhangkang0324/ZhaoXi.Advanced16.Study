using MyAttribute.Extend;
using MyAttribute.ValidateExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute {
    public class UserInfo {
        public int Id { get; set; }

        [Required("Name的值不能为空")]
        public string Name { get; set; }

        public int Age { get; set; }

        public long QQ { get; set; }


        [Required("Mobile的值不能为空")]
        [Length(11, 11, _ErrorMessage = "手机号必须为11位数")]
        public string Mobile { get; set; }

        public UserStateEnum State { get; set; }

        public string UserStateDescription
        {
            get
            {
                return this.State.GetRemark();
            }
        }
    }
}
