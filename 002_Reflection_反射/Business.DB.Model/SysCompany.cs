﻿namespace Business.DB.Model
{
    public class SysCompany : BaseModel
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public int? LastModifyId { get; set; }
        public DateTime? LastModifyTime { get; set; }

    }
}
