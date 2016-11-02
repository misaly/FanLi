using QConnectSDK;
using QConnectSDK.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FanLi.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult LoginQQ(string returnUrl)
        {

            this.Session["RETURN_URL"] = returnUrl;
            var context = new QzoneContext();
            string state = Guid.NewGuid().ToString().Replace("-", "");
            Session["requeststate"] = state;
            string scope = "get_user_info,add_share,list_album,upload_pic,check_page_fans,add_t,add_pic_t,del_t,get_repost_list,get_info,get_other_info,get_fanslist,get_idolist,add_idol,del_idol,add_one_blog,add_topic,get_tenpay_addr";
            var authenticationUrl = context.GetAuthorizationUrl(state, scope);
            return new RedirectResult(authenticationUrl);
        }


        //public ActionResult QQConnect(LoginModel model)
        //{
        //    if (Request.Params["code"] != null)
        //    {
        //        QOpenClient qzone = null;

        //        var verifier = Request.Params["code"];
        //        var state = Request.Params["state"];
        //        string requestState = Session["requeststate"].ToString();

        //        if (state == requestState)
        //        {
        //            qzone = new QOpenClient(verifier, state);
        //            var currentUser = qzone.GetCurrentUser();
        //            if (this.Session["QzoneOauth"] == null)
        //            {
        //                this.Session["QzoneOauth"] = qzone;
        //            }
        //            var friendlyName = currentUser.Nickname;

        //            var isPersistentCookie = true;
        //            SetAuthCookie(qzone.OAuthToken.OpenId, isPersistentCookie, friendlyName);

        //            return Redirect(Url.Action("Index", "Home"));
        //        }

        //    }
        //    return View();
        //}


    }
}