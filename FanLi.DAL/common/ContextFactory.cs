using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// </summary>
    public class ContextFactory
    {

        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static FanLiDbContext GetCurrentContext()
        { 
            FanLiDbContext _nContext = CallContext.GetData("FanLiContext") as FanLiDbContext;
            if (_nContext == null)
            {
                _nContext = new FanLiDbContext();
                CallContext.SetData("FanLiContext", _nContext);
            }
            return _nContext;
        }
    }
}
