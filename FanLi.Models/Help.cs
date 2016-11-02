
using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	/// <summary>
	/// Help:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Help
	{
        [Key]
        public int Id { get; set; }
        public int HelpTypeId { get; set; }
        public virtual HelpType HelpType { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime CreateTime { get; set; }

    }
}

