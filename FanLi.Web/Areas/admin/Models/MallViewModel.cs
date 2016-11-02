using FanLi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class MallsViewListModel
    {
        public PagedList<Malls> Infos { get; set; }
    }
    public class MallTypeViewListModel
    {
        public IList<MallType> Infos { get; set; }
    }

    public class MallTypeAddViewModel
    {
        [Required(ErrorMessage = "必填")]
        [StringLength(50, MinimumLength =2 , ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "类型名称")]
        public string Name { get; set; }
    }
    public class MallsAddViewModel
    {
        [Required(ErrorMessage = "必填")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "英文名或拼音")]
        public string EnName { get; set; }
         
        [Required(ErrorMessage = "必填")] 
        [Display(Name = "字母关键字")]
        public string LetterKey { get; set; }
        [Display(Name = "LOGO")]
        public string Logo { get; set; }
        [Display(Name = "最高折扣")]
        public string MaxDisc { get; set; }
        [Display(Name = "评分")]
        public decimal Score { get; set; }
        [Display(Name = "简单介绍")]
        public string Intro { get; set; }
        [Display(Name = "商城地址")]
        public string Url { get; set; }
        //[Display(Name = "折扣模式下的地址")]
        //public string OurUrl { get; set; }
        [Display(Name = "折扣详情")]
        public string Detail { get; set; }
        [Display(Name = "注意事项")]
        public string Matter { get; set; }
        [Display(Name = "所属分类")]
        public int MallTypeId { get; set; }
    }
}