using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.Models
{
    /// <summary>
    /// 广告位
    /// </summary>
    public class AdPosition
    {
        public int Id { get; set; }
        /// <summary>
        /// 广告位名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// 该广告位能放的广告数量
        /// </summary>
        public int Count { get; set; }

        private ICollection<AdList> _AdList;
        public virtual ICollection<AdList> AdList
        {
            get { return _AdList ?? (_AdList = new List<AdList>()); }
            protected set { _AdList = value; }
        }
    }
}
