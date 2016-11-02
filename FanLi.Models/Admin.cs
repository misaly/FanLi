using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
        [Key]
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string TrueName { get; set; }
        /// <summary>
        /// 分组
        /// </summary>
        public int AdminRoleID { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态 0:正常 1:锁定
        /// </summary>
        public int Status { get; set; }
        public virtual AdminRole AdminRole { get; set; }
       
    }
}

