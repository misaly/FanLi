using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	/// <summary>
	/// Malls:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Malls
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// eg:淘宝：taobao
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 所属字母关键字（a-z）
        /// </summary>
        public string LetterKey { get; set; }
        
        public string Logo { get; set; }
        /// <summary>
        /// 最高折扣
        /// </summary>
        public string MaxDisc { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public decimal Score { get; set; }
        /// <summary>
        /// 商城介绍
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// 商城网址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 折扣模式下的地址--没用的
        /// </summary>
        public string OurUrl { get; set; }
        /// <summary>
        /// 折扣详情
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Matter { get; set; }

        public int MallTypeId { get; set; }
        public virtual MallType MallType { get; set; }

        private ICollection<Products> _Products;
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Products> Products
        {
            get { return _Products ?? (_Products = new List<Products>()); }
            protected set { _Products = value; }
        }
    }
}

