using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FanLi.Models;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    /// <summary>
    /// 登录
    /// </summary>
    public class AdminLoginViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "用户名")]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string LoginPwd { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "验证码")]
        public string VerificationCode { get; set; }

    }
    /// <summary>
    /// 添加管理员
    /// </summary>
    public class AddAdminViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "真实姓名")]
        public string TrueName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string LoginPwd { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Compare("LoginPwd", ErrorMessage = "两次输入的密码不一致")]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 角色
        /// </summary> 
        [Display(Name = "角色")]
        public int RoleId { get; set; }
    }

    /// <summary>
    /// 修改密码视图模型
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// 原密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string OriginalPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "新密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
    public class AdminListViewMode
    {
        public PagedList<Admin> Infos { get; set; }
    }
    public class AdminRoleListViewMode
    {
        public PagedList<AdminRole> Infos { get; set; }

    }
    public class AdminRoleAddViewModel
    {
        [Required(ErrorMessage = "必填")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }


        [StringLength(200, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "角色描述")]
        public string Description { get; set; }

        [Display(Name = "功能权限")]
        public string RolePower { get; set; }
    }
    
    
}