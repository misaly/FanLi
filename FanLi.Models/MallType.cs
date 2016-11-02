using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	/// <summary>
	/// MallType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MallType
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 商城数量
        /// </summary>
        public int MallNum { get; set; }

        private ICollection<Malls> _Malls; 
        public virtual ICollection<Malls> Malls
        {
            get { return _Malls ?? (_Malls = new List<Malls>()); }
            protected set { _Malls = value; }
        }
    }
}

