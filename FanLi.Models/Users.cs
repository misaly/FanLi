using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	 
	[Serializable]
	public partial class Users
	{
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPhoto { get; set; }
        /// <summary>
        /// vip
        /// </summary>
        public int Vip { get; set; }
        public string QQ { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public int provDLID { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public int cityDLID { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public int ditDLID { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 上一次登陆时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 上次登录IP 
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int LoginNum { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 1会员 2商家 3代理
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 状态 0:正常 1:锁定
        /// </summary>
        public int Status { get; set; }

        private ICollection<Favorite> _Favorites;
        /// <summary>
        /// 收藏
        /// </summary>
        public virtual ICollection<Favorite> Favorites
        {
            get { return _Favorites ?? (_Favorites = new List<Favorite>()); }
            protected set { _Favorites = value; }
        }


        private ICollection<VideoComment> _VideoComment;
        /// <summary>
        /// 视频评论
        /// </summary>
        public virtual ICollection<VideoComment> VideoComment
        {
            get { return _VideoComment ?? (_VideoComment = new List<VideoComment>()); }
            protected set { _VideoComment = value; }
        }

        private ICollection<VideoZan> _VideoZan;
        /// <summary>
        /// 视频点赞
        /// </summary>
        public virtual ICollection<VideoZan> VideoZan
        {
            get { return _VideoZan ?? (_VideoZan = new List<VideoZan>()); }
            protected set { _VideoZan = value; }
        }
    }
}

