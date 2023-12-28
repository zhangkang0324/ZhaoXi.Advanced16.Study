using MyAttribute.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute {
    /// <summary>
    /// 比方说有一个用户信息，用户信息中有一个状态字段;在数据库中保存数据的时候，保存的是1,2,3  对应的就是这个枚举；数据库中保存的是数字，但是我们在查询到数据以后，展示给界面的时候，能展示数据吗？---需要展示一个文字描述
    /// </summary>
    //[RemarkAttribute]
    public enum UserStateEnum {
        /// <summary>
        /// 正常状态---改成 “正常”
        /// </summary>
        [Remark("正常状态")]
        Normal = 1,
        /// <summary>
        /// 已冻结
        /// </summary>
        [Remark("已冻结")]
        Frozen = 2,

        /// <summary>
        /// 已删除
        /// </summary>
        [Remark("已删除")]
        Deleted = 3,


        [Remark("其他")]
        Other = 4,


        [Remark("Other1Other1Other1Other1Other1Other1Other1")]
        Other1 = 5
    }
}
