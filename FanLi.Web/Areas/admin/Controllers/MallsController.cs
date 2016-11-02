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
    public class MallsController : Controller
    {
        private IMallsService mallsBll = new MallsBLL();
        private IMallTypeService malltypeBll = new MallTypeBLL();
        // GET: admin/Malls
        public ActionResult list(int page = 1, int pageSize = 20)
        {

            int totalCount = 0;
            PagedList<Malls> InfoPager = mallsBll.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            MallsViewListModel index = new MallsViewListModel();

            index.Infos = InfoPager;
            return View(index);
        }

        public ActionResult add()
        {
            List<MallType> typelist = malltypeBll.FindList(p => true, true, "Id").ToList();
            ViewData["mtypelist"] = typelist;
            return View();
        }
        public ActionResult addType()
        {
            return View();
        }
        public ActionResult listType()
        {
            MallTypeViewListModel _model = new MallTypeViewListModel();
            var _rows = malltypeBll.FindList(m => true, true, "Id").ToList();
            _model.Infos = _rows;
            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(Malls model)
        {
            if (ModelState.IsValid)
            {
                model = mallsBll.Add(model);
                if (model.Id > 0)
                {
                    //在商城分类下数量加1
                    MallType type = malltypeBll.Find(mt => mt.Id == model.MallTypeId);
                    type.MallNum += 1;
                    malltypeBll.Update(type);
                    return RedirectToAction("list");// Response.Write("添加成功");
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addType(MallType model)
        {
            if (ModelState.IsValid)
            {
                model.MallNum = 0;
                model = malltypeBll.Add(model);
                if (model.Id > 0)
                {
                    Response.Write("添加成功");
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }

    }
}