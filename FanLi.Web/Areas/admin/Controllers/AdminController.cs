using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanLi.Web.Areas.admin.Models;
using FanLi.IBLL;
using FanLi.Models;
using FanLi.Common;
using FanLi.BLL;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Controllers
{
   // [Authorize]
    public class AdminController : Controller
    {
        private IAdminService adminbll=new AdminBLL();
        private IAdminRoleService adminRolebll = new AdminRoleBLL();
        // GET: admin/Admin
        public ActionResult list(int page = 1, int pageSize = 2)
        {
            int totalCount = 0;
            PagedList<Admin> InfoPager = adminbll.FindPageList(page, pageSize, out totalCount, "Id", true).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            AdminListViewMode index = new AdminListViewMode();

            index.Infos = InfoPager;
            return View(index);
        }
        
        public ActionResult add()
        {
            List<AdminRole> Rolelist = adminRolebll.FindList(u => true, true, "Id").ToList();
            IEnumerable<SelectListItem> _roleList = Rolelist.Select(a => new SelectListItem
            {
                Text = a.RoleName,
                Value = a.Id.ToString()
            });
            ViewData["RoleList"] = _roleList;
            return View("add");
        }
        

        public ActionResult addRole()
        {
            List<commonModel> list = GetXmlInfo.GetcommonList("adminPower"); 
            ViewData["PowerList"] = list;
            return View("addRole");
        }
        public ActionResult listRole(int page = 1, int pageSize = 2)
        {
            int totalCount = 0; 
            PagedList<AdminRole> InfoPager = adminRolebll.FindPageList(page, pageSize, out totalCount, "Id", true).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            AdminRoleListViewMode index = new AdminRoleListViewMode();
             
            index.Infos = InfoPager; 
            return View("listRole", index);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(AddAdminViewModel adminview)
        { 
            if (adminbll.Exist(adminview.UserName)) ModelState.AddModelError("UserName", "名称已存在");
            Admin _admin = new Admin()
            {
                LoginName = adminview.UserName,
                //默认用户组代码写这里
                TrueName = adminview.TrueName,
                LoginPwd = Utils.MD5(adminview.LoginPwd),
                AdminRoleID = adminview.RoleId,
                //用户状态问题
                Status = 0,
                CreateTime = System.DateTime.Now
            };
            _admin = adminbll.Add(_admin);
            if (_admin.Id > 0)
            {
                return RedirectToAction("list");
            }
            else { return RedirectToAction("add"); } 

        }

        public ActionResult EditPwd()
        {
            return View("EditPwd");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditPwd(ChangePasswordViewModel editPwd)
        {
            if (ModelState.IsValid)
            {
                var _admin = adminbll.Find(User.Identity.Name);
                if (_admin.LoginPwd ==Utils.MD5(editPwd.OriginalPassword))
                {
                    _admin.LoginPwd = Utils.MD5(editPwd.Password);
                    if (adminbll.Update(_admin)) ModelState.AddModelError("", "修改密码成功");
                    else ModelState.AddModelError("", "修改密码失败");
                }
                else ModelState.AddModelError("", "原密码错误");
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult addRole(AdminRole adminrole)
        {
            if (ModelState.IsValid)
            {
                
                if (adminRolebll.Exist(adminrole.RoleName)) ModelState.AddModelError("RoleName", "角色名称已存在");
                else
                {
                    AdminRole _adminRole = new AdminRole()
                    {
                        RoleName = adminrole.RoleName,
                        RolePower = adminrole.RolePower,
                        Description= adminrole.Description
                    };
                    _adminRole = adminRolebll.Add(_adminRole);
                    if (_adminRole.Id > 0)
                    {
                        return RedirectToAction("listRole");  
                    }
                    else { ModelState.AddModelError("", "添加失败！"); }
                }
            }
            return View("add"); 
        }

       
    }
}