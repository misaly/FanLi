using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class UsersMap : EntityTypeConfiguration<Users>
    {
        public UsersMap()
        {
            this.ToTable("Users");
            Property(u => u.UserName).IsRequired().HasMaxLength(50).IsUnicode();
            Property(u => u.Password).IsRequired().HasMaxLength(100).IsUnicode();
            Property(u => u.Tel).HasMaxLength(20);
            Property(u => u.Email).HasMaxLength(100).IsUnicode();
            Property(u => u.HeadPhoto).HasMaxLength(200).IsUnicode();
            Property(u => u.QQ).HasMaxLength(20).IsUnicode();
            Property(u => u.TrueName).HasMaxLength(50);
            Property(u => u.Address).HasMaxLength(100);
        }
    }
}
