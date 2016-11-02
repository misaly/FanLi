using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class AdminRole
    {
      
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }


        [StringLength(200, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "角色描述")]
        public string Description { get; set; }

        [Display(Name = "功能权限")]
        /// <summary>
        /// 角色的功能权限，用,分隔，
        ///   功能在配置文件中(或页面中)；直接在添加角色的时候选择
        /// </summary>
        public string RolePower { get; set; }

        private ICollection<Admin> _Admins;        
        public virtual ICollection<Admin> Admins
        {
            get { return _Admins ?? (_Admins = new List<Admin>()); }
            protected set { _Admins = value; }
        }
    }
}
