using FanLi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class NewsListViewModel
    {
        public PagedList<News> Infos { get; set; }
    }
    public class NewsAddViewModel
    {

        [Required(ErrorMessage = "必填")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "必填")] 
        [Display(Name = "内容")]
        public string Contents { get; set; }
        [Display(Name = "类型")]
        public int Type { get; set; }
    }
}