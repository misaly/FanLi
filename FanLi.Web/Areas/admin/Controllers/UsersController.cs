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
    public class UsersController : Controller
    {
        // GET: admin/Users
        private IUserService userBll = new UserBLL();
        // GET: admin/Video
        public ActionResult list(int page = 1, int pageSize = 20)
        {
            int totalCount = 0;
            PagedList<Users> InfoPager = userBll.FindPageList(page, pageSize, out totalCount, "Id", true).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            UsersListViewModel index = new UsersListViewModel();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult info(int id)
        {
            return View("userInfo");
        }
    }
}