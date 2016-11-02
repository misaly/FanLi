using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.Models;
using System.Security.Claims;

namespace FanLi.IBLL
{
    public interface IUserService : IBaseService<Users>
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
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        Users Find(int userID);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Users Find(string userName);
        /// <summary>
        /// 用于登录的 身份认证系统
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        ClaimsIdentity CreateIdentity(Users user, string authenticationType);
    }
}
