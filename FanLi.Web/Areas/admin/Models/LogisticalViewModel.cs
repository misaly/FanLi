using FanLi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class LogisticalViewModel
    {
        public PagedList<Logistical> infos { get; set; }
    }
    public class LogisticalAddViewModel
    {
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "物流公司名称")]
        public string Name { get; set; }



        [Display(Name = "公司的LOGO")]
        public string Icon { get; set; }


        [Display(Name = "详细介绍")]
        public string Detail { get; set; }

        [Display(Name = "链接地址")]
        public string Url { get; set; }
    }
}