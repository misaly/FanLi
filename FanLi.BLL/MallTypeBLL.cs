using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.IBLL;
using FanLi.Models;
using FanLi.DAL;
using FanLi.IDAL;

namespace FanLi.BLL
{
    public class MallTypeBLL : BaseService<MallType>, IMallTypeService
    {
        public MallTypeBLL() : base(RepositoryFactory.MallTypeDAL)
        {
        }
    }
}
