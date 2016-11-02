using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
    /// <summary>
    /// 产品类型 分三级
    /// </summary>
    [Serializable]
    public partial class ProductType
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string tpName { get; set; }
        /// <summary>
        /// 上一级ID，第一级为0
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tpIcon { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int tpLevel { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int tpSort { get; set; }
        private ICollection<Products> _Products;
        /// <summary>
        /// 产品
        /// </summary>
        public virtual ICollection<Products> Products
        {
            get { return _Products ?? (_Products = new List<Products>()); }
            protected set { _Products = value; }
        }
    }
}

