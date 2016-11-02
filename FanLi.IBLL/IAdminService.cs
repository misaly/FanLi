using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.Models;
using System.Security.Claims;

namespace FanLi.IBLL
{
    public interface IAdminService:IBaseService<Admin>
    {

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>布尔值</returns>
        bool Exist(string userName);
        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Admin Find(string userName);
        ClaimsIdentity CreateIdentity(Admin admin, string authenticationType);


         
        //IQueryable<Admin> Order(IQueryable<Admin> entitys, int roderCode);

        /// <summary>
        /// 查询分页数据列表
        /// </summary> 
       // IQueryable<Admin> FindPageList(out int totalRecord, int pageIndex, int pageSize,  string title,  int orderCode);
    }
}
