using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
    /// <summary>
    /// 视频点赞
    /// </summary>
    [Serializable]
	public partial class VideoZan
	{
		[Key]
		public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }
      
        public DateTime CreateTime { get; set; }

    }
}

