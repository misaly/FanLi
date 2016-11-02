using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
    /// <summary>
    /// 视频表
    /// </summary>
    [Serializable]
    public partial class Video
    {

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 封面图
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNum { get; set; }
        /// <summary>
        /// 点赞数量
        /// </summary>
        public int ZanNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }

        private ICollection<VideoComment> _VideoComment;
        public virtual ICollection<VideoComment> VideoComment
        {
            get { return _VideoComment ?? (_VideoComment = new List<VideoComment>()); }
            protected set { _VideoComment = value; }
        }

        private ICollection<VideoZan> _VideoZan;
        public virtual ICollection<VideoZan> VideoZan
        {
            get { return _VideoZan ?? (_VideoZan = new List<VideoZan>()); }
            protected set { _VideoZan = value; }
        }
    }
}

