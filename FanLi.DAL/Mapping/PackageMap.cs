using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class PackageMap : EntityTypeConfiguration<Package>
    {
        public PackageMap()
        {
            this.ToTable("Package");
            Property(p => p.UserName).HasMaxLength(30).IsRequired();
            Property(p => p.Tel).HasMaxLength(20).IsRequired().IsUnicode(false);
            Property(p => p.FromAddress).HasMaxLength(100).IsRequired();
            HasRequired(p => p.Logistical).WithMany(x => x.Package).HasForeignKey(bc => bc.LogisticalId);
        }
    }
}