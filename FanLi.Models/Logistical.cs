using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanLi.Models
{
    /// <summary>
    /// 物流公司信息
    /// </summary>
    [Serializable]
	public partial class Logistical
	{
		 
		[Key]
		public int Id { get; set; } 
        public string Name { get; set; } 
        public string Icon { get; set; } 
        public string Detail { get; set; } 
        public string Url { get; set; }

        private ICollection<Package> _Package;
        public virtual ICollection<Package> Package
        {
            get { return _Package ?? (_Package = new List<Package>()); }
            protected set { _Package = value; }
        }

    }
}

