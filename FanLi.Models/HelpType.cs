using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	/// <summary>
	/// HelpType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HelpType
	{
        [Key]
        public int Id { get; set; }
		/// <summary>
        /// 二级分类
        /// </summary>
		public int ParentId { get; set; }
        public string TName { get; set; }
        public int Sort { get; set; }
        private ICollection<Help> _Helps;
        /// <summary>
        ///  
        /// </summary>
        public virtual ICollection<Help> Helps
        {
            get { return _Helps ?? (_Helps = new List<Help>()); }
            protected set { _Helps = value; }
        }
    }
}

