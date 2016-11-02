using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanLi.Models;
using FanLi.BLL;
using FanLi.IBLL;
using FanLi.Common;
using System.Xml.Linq;
using FanLi.Web;
using Webdiyer.WebControls.Mvc;
using FanLi.Web.Areas.admin.Models;

namespace FanLi.Web.Areas.admin.Controllers
{
    public class AdListController : Controller
    {
        private IAdListService adlistBll = new AdListBLL();
        private IAdPositionService adpositionBll = new AdPositionBLL();
        // GET: admin/AdList
        public ActionResult list(int page = 1, int pageSize = 20)
        {
            int totalCount = 0;
            PagedList<AdList> InfoPager = adlistBll.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            AdListViewMode index = new AdListViewMode();

            index.Infos = InfoPager;
            return View(index);
        }

        public ActionResult add()
        {
            ////获取广告位   

            List<AdPosition> list = adpositionBll.FindList(t => true, true, "Id").ToList();
            IEnumerable<SelectListItem> _list = list.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            });
            ViewData["PositionList"] = _list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(AdListAddViewModel _adlist)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase pfb = Request.Files["fileIMG"];
                string outPath = ""; 
                string msg =  UploadImg.Upload(pfb, out outPath);
                if (msg != "") { }
                AdList model = new AdList()
                {
                    AdPositionId = _adlist.AdPositionId,
                    Img = _adlist.Img,
                    IsShow = _adlist.IsShow,
                    Src = _adlist.Src,
                    Title = _adlist.Title
                };
                AdPosition position= adpositionBll.Find(p => p.Id == model.AdPositionId);
                //判断广告数量
                int count = adlistBll.Count(a => a.AdPositionId == model.AdPositionId);
                if (count >= position.Count)
                {
                    ModelState.AddModelError("", "广告数量已满！");
                }
                else
                {
                    model = adlistBll.Add(model);
                    if (model.Id > 0)
                    {
                        return RedirectToAction("list");//Response.Write("添加成功");
                    }
                    else { ModelState.AddModelError("", "添加失败！"); }
                }
            }
            return View(_adlist);
        }


        public ActionResult listPosition(int page = 1, int pageSize = 20)
        {
            int totalCount = 0;
            PagedList<AdPosition> InfoPager = adpositionBll.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            AdPositionListViewModel index = new AdPositionListViewModel();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult addPosition()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addPosition(AdPositionAddViewModel _model)
        {
            if (ModelState.IsValid)
            {
                AdPosition model = new AdPosition()
                {
                    Count = _model.Count,
                    Intro = _model.Intro,
                    Name = _model.Name
                };
                model = adpositionBll.Add(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("listPosition"); 
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }
    }
}