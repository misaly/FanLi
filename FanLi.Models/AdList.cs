
using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	/// <summary>
	/// 广告
	/// </summary>
	[Serializable]
	public partial class AdList
	{ 
		[Key]
		public int Id { get; set; } 
        public string Title { get; set; } 
        public string Img { get; set; } 
        public int AdPositionId { get; set; }
        public virtual AdPosition AdPosition { get; set; }
        public string Src { get; set; } 
        public bool IsShow { get; set; }

    }
}

