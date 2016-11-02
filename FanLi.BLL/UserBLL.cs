using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.IBLL;
using FanLi.Models;
using FanLi.DAL;
using FanLi.IDAL;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace FanLi.BLL
{
    public class UserBLL : BaseService<Users>, IUserService
    {
        public UserBLL() : base(RepositoryFactory.UserDAL) { }

        public ClaimsIdentity CreateIdentity(Users user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.TrueName));
            return _identity;
        }

        public bool Exist(string userName) { return CurrentRepository.Exist(u => u.UserName == userName); }

        public Users Find(int userID) { return CurrentRepository.Find(u => u.Id == userID); }

        public Users Find(string userName) { return CurrentRepository.Find(u => u.UserName == userName); }

    }
}
