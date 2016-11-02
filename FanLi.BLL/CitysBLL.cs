using FanLi.IBLL;
using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.IDAL;
using FanLi.DAL;

namespace FanLi.BLL
{
    public class CitysBLL : BaseService<Citys>, ICitysService
    {
        public CitysBLL() : base(RepositoryFactory.CitysDAL)
        {
        }
    }
}
