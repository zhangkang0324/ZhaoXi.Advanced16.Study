using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.DbProxy.Model;

namespace Zhaoxi.DBProxy.Models.Models {
    public partial class Commodity : BaseModel {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
