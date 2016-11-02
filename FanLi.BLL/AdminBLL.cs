using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.Models;
using FanLi.IBLL;
using FanLi.DAL;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace FanLi.BLL
{
    public class AdminBLL : BaseService<Admin>, IAdminService
    {
        public AdminBLL() : base(RepositoryFactory.AdminDAL) { }

        public bool Exist(string loginName) { return CurrentRepository.Exist(u => u.LoginName == loginName); }

        public Admin Find(int Id) { return CurrentRepository.Find(u => u.Id == Id); }

        public Admin Find(string loginName) { return CurrentRepository.Find(u => u.LoginName == loginName); }
        public ClaimsIdentity CreateIdentity(Admin admin, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, admin.LoginName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", admin.TrueName));
            return _identity;
        }

        
 

    }
 
}
