
using System;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
	 /// <summary>
		/// 包裹代寄收
		/// </summary>
	[Serializable]
	public partial class Package
	{
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 寄件人姓名
        /// </summary>
        public string UserName { get; set; }
        /// 手机/电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 选择物流公司
        /// </summary>
        public int LogisticalId { get; set; }
        public virtual Logistical Logistical { get; set; }
        /// <summary>
        /// 寄件的省份
        /// </summary>
        public int FromProv { get; set; }
        /// <summary>
        /// 寄件的城市
        /// </summary>
        public int FromCity { get; set; }
        /// <summary>
        /// 寄件的地区
        /// </summary>
        public int FromDit { get; set; }
        /// <summary>
        /// 寄件的详细地址
        /// </summary>
        public string FromAddress { get; set; }
        /// <summary>
        /// 上门收件时间
        /// </summary>
        public DateTime TakeTime { get; set; }
        
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态 1:等待收件 2:已收件
        /// </summary>
        public int Statue { get; set; }

    }
}

