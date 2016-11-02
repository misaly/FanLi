using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Models
{
    public class UsersListViewModel
    {
        public PagedList<Users> Infos { get; set; }
    }
}