namespace Business.DB.Model
{
    public class SysUser : BaseModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int? Status { get; set; }
        public string? Phone { get; set; }
        public long? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public long? QQ { get; set; }
        public string? WeChat { get; set; }
        public int? Sex { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? CreateId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifyId { get; set; }
        public int? CompanyId { get; set; }
    }
}
