using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanLi.Models;
using FanLi.BLL;
using FanLi.IBLL;
using Webdiyer.WebControls.Mvc;
using FanLi.Web.Areas.admin.Models;

namespace FanLi.Web.Areas.admin.Controllers
{
    public class VideoController : Controller
    {
        private IVideoService videoBll = new VideoBLL();
        private IVideoCommentService videocommentBll = new VideoCommentBLL();
        private IVideoZanService videozanBll = new VideoZanBLL();
        // GET: admin/Video
        public ActionResult list(int page = 1, int pageSize = 20)
        {
            int totalCount = 0;
            PagedList<Video> InfoPager = videoBll.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            VideoListViewModel index = new VideoListViewModel();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(VideoAddViewModel _model)
        {
            if (ModelState.IsValid)
            {
                Video video = new Video()
                {
                    Title = _model.Title,
                    CommentNum = 0,
                    ZanNum = 0,
                    CreateTime = DateTime.Now,
                    Img = _model.Img,
                    Src=_model.Src
                };
                video = videoBll.Add(video);
                if (video.Id > 0)
                {
                   return RedirectToAction("list"); 
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }
        public ActionResult zan(int vid=0, int page = 1, int pageSize = 20)
        {
            PagedList<VideoZan> InfoPager = null;
            int totalCount = 0;
            if (vid == 0)
                return RedirectToAction("list");
            else
                InfoPager = videozanBll.FindPageList(vc => vc.VideoId == vid, page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);

            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            VideoZanListViewModel index = new VideoZanListViewModel();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult comment(int vid = 0, int page = 1, int pageSize = 20)
        {

            PagedList<VideoComment> InfoPager = null;
            int totalCount = 0;
            if (vid == 0)
                return RedirectToAction("list");
            else
                InfoPager = videocommentBll.FindPageList(vc => vc.VideoId == vid, page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);

            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            VideoCommentListViewModel index = new Models.VideoCommentListViewModel();

            index.Infos = InfoPager;
            return View(index);

        }
        
    }
}