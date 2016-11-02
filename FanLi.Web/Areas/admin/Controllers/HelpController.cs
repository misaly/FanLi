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
    public class HelpController : Controller
    {
        private IHelpService helpBll = new HelpBLL();
        private IHelpTypeService helptypeBll = new HelpTypeBLL();
        // GET: admin/Help
        public ActionResult list(int page = 1, int pageSize = 20)
        {

            int totalCount = 0;
            PagedList<Help> InfoPager = helpBll.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            HelpListViewModel index = new HelpListViewModel();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult add()
        {
            List<HelpType> onelist = helptypeBll.FindList(p => p.ParentId == 0, true, "Id").ToList();
            ViewData["htypeone"] = onelist;
            return View();
        }
        public ActionResult addType()
        {
            List<HelpType> onelist = helptypeBll.FindList(p => p.ParentId == 0, true, "Id").ToList();
            ViewData["htypeone"] = onelist;
            return View();
        }
        public ActionResult listType(int pid=0)
        {
            HelpTypeListViewModel _model = new HelpTypeListViewModel();
            var _rows = helptypeBll.FindList(p => p.ParentId == pid, true,"Id").ToList();
             
            if (pid == 0)
                _model.parentName = "无";
            else
                _model.parentName = helptypeBll.Find(m => m.Id == pid).TName;

            _model.infos = _rows;

            return View(_model);

 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(Help model)
        {
            if (ModelState.IsValid)
            {
                model.CreateTime = DateTime.Now;
                model = helpBll.Add(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("list");
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }


        [HttpPost]
        public JsonResult GetHelpType()
        {  
            int pid = Convert.ToInt32(Request.Form["pid"]);
            List<HelpType> typetlist = helptypeBll.FindList(p => p.ParentId == pid, true, "Id").ToList();
            return Json(typetlist);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addType(HelpType model)
        {
            if (ModelState.IsValid)
            {
                model = helptypeBll.Add(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("list");
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }
    }
}