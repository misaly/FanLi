using FanLi.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FanLi.Common;
using System.Drawing;
using Microsoft.Owin.Security;
using FanLi.Web.Areas.admin.Models;
using FanLi.BLL;
using Microsoft.AspNet.Identity;
using FanLi.IBLL;

namespace FanLi.Web.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        private IAdminService adminbll = new AdminBLL();
        // GET: admin/Login
        public ActionResult Index()
        {
            return View("Login");
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != login.VerificationCode.ToUpper())
                {
                    ModelState.AddModelError("VerificationCode", "1验证码不正确");
                    return View(login);
                }
                var _admin = adminbll.Find(login.LoginName);
                if (_admin == null) ModelState.AddModelError("LoginName", "用户名不存在");
                else if (_admin.LoginPwd == Utils.MD5(login.LoginPwd))
                {
                    var _identity = adminbll.CreateIdentity(_admin, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, _identity);
                    return RedirectToAction("Index", "Main");
                }
                else ModelState.AddModelError("LoginPwd", "密码错误");
            }
            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Url.Content("~/"));
        }

        
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerificationCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string verificationCode = validateCode.CreateValidateCode(4);
            //Bitmap _img = validateCode.CreateVerificationImage(verificationCode, 100, 42);
            // _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] code= validateCode.CreateValidateGraphic(verificationCode, 100, 42);
            Response.BinaryWrite(code);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }
    }
}