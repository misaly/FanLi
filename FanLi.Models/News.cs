using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
    /// <summary>
    ///  新闻表
    /// </summary>
	[Serializable]
	public partial class News
	{

        [Key]
        public int Id { get; set; }
       
        public string Title { get; set; }
       
        public string Contents { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 1:新闻 2:公告
        /// </summary>
        public int Type { get; set; }

    }
}

