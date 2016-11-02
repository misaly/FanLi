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
    public class PackageController : Controller
    {
        private IPackageService packageBll = new PackageBLL();
        // GET: admin/Package
        public ActionResult list(int page = 1, int pageSize = 20)
        {
            int totalCount = 0;
            PagedList<Package> InfoPager = packageBll.FindPageList(page, pageSize, out totalCount, "Id", true).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            PackageListViewModel index = new PackageListViewModel();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult info(int id)
        {
            return View("info");
        }
    }
}