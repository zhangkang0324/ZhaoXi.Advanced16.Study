namespace Zhaoxi.DbProxy.Model {
    public class BaseModel {

        /// <summary>
        /// 在ORM框架的使用中，要求数据库表必须有一个主键。
        /// </summary>
        /// 主键 --代表必然有一个主键
        public int Id { get; set; }
    }
}
