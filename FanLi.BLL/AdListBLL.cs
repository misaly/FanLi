using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.Models;
using FanLi.IBLL;
using FanLi.DAL;
using System.Linq.Expressions;

namespace FanLi.BLL
{
    public class AdListBLL : BaseService<AdList>, IAdListService
    {
        public AdListBLL() : base(RepositoryFactory.AdListDAL) { }
        
        // public bool Exist(int id) { return CurrentRepository.Exist(u => u.Id == id); }

        // public AdList Find(int Id) { return CurrentRepository.Find(u => u.Id == Id); }

        //public AdList Find(string loginName) { return CurrentRepository.Find(u => u.LoginName == loginName); }
    }
}
