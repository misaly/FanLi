
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	 
	[Serializable]
	public partial class Products
	{
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string proName { get; set; }
        /// <summary>
        /// 上传的商家 0表示平台管理员
        /// </summary>
        public int UserId { get; set; }
      
        public string Pic { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal OrigPrice { get; set; }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 让价，优惠多少钱
        /// </summary>
        public decimal OfferPrice { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int VipScore { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public int SellNum { get; set; }
        /// <summary>
        /// 产品的购买地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 商城ID
        /// </summary>
        public int MallsId { get; set; }
        public virtual Malls Malls { get; set; }
        /// <summary>
        /// ProductType.id
        /// </summary>
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 0:未审核 1:审核通过 2:审核不通过
        /// </summary>
        public int IsCheck { get; set; }
        /// <summary>
        /// 上架、下架
        /// </summary>
        public bool IsShow { get; set; }

        private ICollection<Favorite> _Favorites;
        /// <summary>
        /// 收藏
        /// </summary>
        public virtual ICollection<Favorite> Favorites
        {
            get { return _Favorites ?? (_Favorites = new List<Favorite>()); }
            protected set { _Favorites = value; }
        }
    }
}

