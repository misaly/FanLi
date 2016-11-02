using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FanLi.Web.Controllers
{
    //[Authorize]
    public class UserCenterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
       
    }
}
