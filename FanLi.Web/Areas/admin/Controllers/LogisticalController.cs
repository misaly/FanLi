using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanLi.BLL;
using FanLi.IBLL;
using Webdiyer.WebControls.Mvc;
using FanLi.Web.Areas.admin.Models;

namespace FanLi.Web.Areas.admin.Controllers
{
    //[Authorize]
    public class LogisticalController : Controller
    {
        private ILogisticalService logisticalBLL = new LogisticalBLL();
        // GET: admin/Logistical

        public ActionResult list(int page=1,int pageSize=20)
        {
            int totalCount = 0;
            PagedList<Logistical> InfoPager = logisticalBLL.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            LogisticalViewModel index = new LogisticalViewModel();

            index.infos = InfoPager;
            return View(index);
        }
        public ActionResult add()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(Logistical logistical, HttpPostedFileBase upImg)
        {
            if (ModelState.IsValid)
            {
                Upload(upImg);
                logistical = logisticalBLL.Add(logistical);
                    if (logistical.Id > 0)
                    {
                        return Content("添加成功！");

                    }
                    else { ModelState.AddModelError("", "添加失败！"); }
                 
            }
            return View(logistical);
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase upImg)
        {
            string fileName = System.IO.Path.GetFileName(upImg.FileName);
            string filePhysicalPath = Server.MapPath("~/upload/" + fileName);
            string pic = "", error = "";
            try
            {
                upImg.SaveAs(filePhysicalPath);
                pic = "/upload/" + fileName;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(new
            {
                pic = pic,
                error = error
            });
        }
    }
}