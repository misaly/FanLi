using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.IBLL;
using FanLi.Models;
using FanLi.DAL;

namespace FanLi.BLL
{
    public class AdminRoleBLL : BaseService<AdminRole>, IAdminRoleService
    {
        public AdminRoleBLL() : base(RepositoryFactory.AdminRoleDAL)
        {
        }

        public bool Exist(string Name) { return CurrentRepository.Exist(u => u.RoleName == Name); }
    }
}
