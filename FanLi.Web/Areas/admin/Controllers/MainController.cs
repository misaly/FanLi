using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FanLi.Web.Areas.admin.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        // GET: admin/Main
        public ActionResult Index()
        {
            return View("main");
        }
    }
}