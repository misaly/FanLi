using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
    /// <summary>
    /// 视频评论表
    /// </summary>
    [Serializable]
	public partial class VideoComment
	{
		 
		[Key]
		public int Id { get; set; }
        /// <summary>
        /// 评论：回复
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 视频Id；Video.Id
        /// </summary>
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }
        /// <summary>
        /// 评论人：0:管理员
        /// </summary>
        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}

