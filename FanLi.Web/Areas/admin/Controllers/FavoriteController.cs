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
    public class FavoriteController : Controller
    {
        private IFavoriteService favoriteBll = new FavoriteBLL();
        // GET: admin/Favorite
        public ActionResult list(int page = 1, int pageSize = 20)
        {
            int totalCount = 0;
            PagedList<Favorite> InfoPager = favoriteBll.FindPageList(page, pageSize, out totalCount, "Id", true).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            FavoriteListViewMode index = new FavoriteListViewMode();

            index.Infos = InfoPager;
            return View(index);
        }

    }
}