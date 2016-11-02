using FanLi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class VideoListViewModel
    {
        public PagedList<Video> Infos { get; set; }
    }
    public class VideoCommentListViewModel
    {
        public PagedList<VideoComment> Infos { get; set; }
    }
    public class VideoZanListViewModel
    {
        public PagedList<VideoZan> Infos { get; set; }
    }

    public class VideoAddViewModel
    {
        [Required(ErrorMessage = "必填")] 
        [Display(Name = "视频地址")]
        public string Src { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "封面图")]
        public string Img { get; set; } 
    }
}