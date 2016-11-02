using FanLi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class HelpListViewModel
    {
        public PagedList<Help> Infos { get; set; }

    }
    public class HelpTypeListViewModel
    {
        public string parentName { get; set; }
        public IList<HelpType> infos { get; set; }
    }
    public class HelpAddViewModel
    {
        [Required(ErrorMessage = "必选")] 
        [Display(Name = "类型")]
        public int HelpTypeId { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "必填")] 
        [Display(Name = "内容")]
        public string Contents { get; set; }
    }
    public class HelpTypeAddViewModel
    {

        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "名称")]
        public string TName { get; set; }

        [Required(ErrorMessage = "必填")] 
        [Display(Name = "排序")]
        public int Sort { get; set; }

        [Display(Name = "父级")]
        public int ParentId { get; set; }
    }

    
}