using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	/// <summary>
	///  用户的收藏
	/// </summary>
	[Serializable]
	public partial class Favorite
	{
        [Key]
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int ProductsId { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }

    }
}

