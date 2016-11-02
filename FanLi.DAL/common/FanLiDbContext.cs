using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FanLi.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Common;

namespace FanLi.DAL
{
    /// <summary>
    /// 数据上下文
    /// </summary>
    public class FanLiDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<AdminFunction> AdminFunction { get; set; }
        public DbSet<AdList> AdList { get; set; }
        public DbSet<AdPosition> AdPosition { get; set; }
        public DbSet<Favorite> Favorite { get; set; }

        public DbSet<Help> Help { get; set; }

        public DbSet<HelpType> HelpType { get; set; }

        public DbSet<Logistical> Logistical { get; set; }

        public DbSet<Malls> Malls { get; set; }
        public DbSet<MallType> MallType { get; set; }

        public DbSet<News> News { get; set; }
        public DbSet<Package> Package { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Video> Video { get; set; }

        public DbSet<VideoComment> VideoComment { get; set; }

        public DbSet<VideoZan> VideoZan { get; set; }

        public DbSet<Citys> Citys { get; set; }
        public FanLiDbContext()
            : base("ConnectionString")
        {
        }
    }
}
