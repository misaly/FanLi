using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class HelpMap : EntityTypeConfiguration<Help>
    {
        public HelpMap()
        {
            this.ToTable("Help");
            Property(h => h.Title).HasMaxLength(200).IsRequired();
            Property(h => h.Contents).HasColumnType("text").IsRequired();
            HasRequired(x => x.HelpType).WithMany(x => x.Helps).HasForeignKey(bc => bc.HelpTypeId);
        }
    }

    public class HelpTypeMap : EntityTypeConfiguration<HelpType>
    {
        public HelpTypeMap()
        {
            this.ToTable("HelpType");
            Property(ht => ht.TName).HasMaxLength(30).IsRequired();
            
        }
    }
}
