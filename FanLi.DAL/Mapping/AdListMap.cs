using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class AdListMap : EntityTypeConfiguration<AdList>
    {
        public AdListMap()
        {
            this.ToTable("AdList");
            Property(a => a.Title).HasMaxLength(100).IsRequired();
            Property(a => a.Img).HasMaxLength(200).IsRequired().IsUnicode(false);
            Property(a => a.Src).HasMaxLength(200).IsUnicode(false);
            HasRequired(a => a.AdPosition).WithMany(a => a.AdList).HasForeignKey(bc => bc.AdPositionId);
        }
    }

    public class AdPositionMap : EntityTypeConfiguration<AdPosition>
    {
        public AdPositionMap()
        {
            this.ToTable("AdPosition");
            Property(a => a.Name).HasMaxLength(100).IsRequired(); 
        }
    }
}
