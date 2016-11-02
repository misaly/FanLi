using FanLi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class ProductListViewModel
    {
        public PagedList<Products> Infos { get; set; }
    }
    public class ProductTypeListViewModel
    {
        public string parentName { get; set; }
        public IList<ProductType> productTypeList { get; set; }
    }

    public partial class ProductsAddViewModel
    {

        [Required(ErrorMessage = "必填")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "产品名称")] 
        public string proName { get; set; }

        [Required(ErrorMessage = "必填")]  
        [Display(Name = "产品图片")]
        public string Pic { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "原价")]
        public decimal OrigPrice { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "售价")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "必填")]
        [Display(Name = "让价")]
        public decimal OfferPrice { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "返积分")]
        public int Score { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "VIP用户返积分")]
        public int VipScore { get; set; }
        
        [Required(ErrorMessage = "必填")]
        [Display(Name = "销售数量")]
        public int SellNum { get; set; }
        
        [Required(ErrorMessage = "必填")]
        [Display(Name = "产品的购买地址")]
        public string Url { get; set; }

       
        [Display(Name = "所属商城")]
        public int MallsId { get; set; }
        public IEnumerable<SelectListItem> ListMalls { get; set; }

        [Display(Name = "产品类型")]
        public int ProductTypeId { get; set; }
        //public IEnumerable<SelectListItem> ListproductType { get; set; }

        /// <summary>
        /// 0:未审核 1:审核通过 2:审核不通过
        /// </summary>
        [Display(Name = "审核状态")]
        public int IsCheck { get; set; }
        /// <summary>
        /// 上架、下架
        /// </summary>
        [Display(Name = "产品状态")]
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

    public partial class ProductTypeAddViewModel
    {
       
        [Required(ErrorMessage = "必填")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "类型名称")]
        public string tpName { get; set; }
       
        [Required(ErrorMessage = "必填")]
        [Display(Name = "父级")]
        public int ParentId { get; set; }

        
        [Display(Name = "ICON图")]
        public string tpIcon { get; set; }
        [Display(Name = "等级")]
        public int tpLevel { get; set; }
        [Display(Name = "排序")]
        public int tpSort { get; set; }

    }
}