using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.DbProxy.Model;

namespace Zhaoxi.DBProxy.Models.Models {
    public partial class Syscompany : BaseModel {
        public int Id { get; set; }

        public string? Name { get; set; }
        public DateTime? CreateTime { get; set; }

        public int? CreatorId { get; set; }

        public int? LastModifyId { get; set; }

        public DateTime? LastModifyTime { get; set; }
    }
}
