using FanLi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class AdListViewMode
    {
        public PagedList<AdList> Infos { get; set; }
    }
    public class AdPositionListViewModel
    {
        public PagedList<AdPosition> Infos { get; set; }
    }
    public class AdListAddViewModel
    {
        [Required(ErrorMessage = "必填")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "广告图")]
        public string Img { get; set; }
        [Display(Name = "广告位")]
        public int AdPositionId { get; set; }

        [Display(Name = "跳转地址")]
        public string Src { get; set; }

        [Display(Name = "是否显示")]
        public bool IsShow { get; set; }
    }
    public class AdPositionAddViewModel
    {
        [Required(ErrorMessage = "必填")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "广告位名称")]
        public string Name { get; set; }

        
        [Display(Name = "描述")]
        public string Intro { get; set; }

        [Display(Name = "广告数量")]
        public int Count { get; set; }
    }
}