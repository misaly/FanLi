using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanLi.Models;
using FanLi.BLL;
using FanLi.IBLL;
using FanLi.Web.Areas.admin.Models;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Controllers
{
    public class NewsController : Controller
    {
        private INewsService newsBll = new NewsBLL();
        // GET: admin/News
        public ActionResult list(int page = 1, int pageSize = 2)
        {
            int totalCount = 0;
            PagedList<News> InfoPager = newsBll.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            NewsListViewModel index = new NewsListViewModel();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(NewsAddViewModel _model)
        {
            if (ModelState.IsValid)
            {
                News news = new News() {
                    CreateTime = DateTime.Now,
                    Title=_model.Title,
                    Type=_model.Type,
                    Contents=_model.Contents
                }; 
                news = newsBll.Add(news);
                if (news.Id > 0)
                {
                    return RedirectToAction("list");
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }
    }
}