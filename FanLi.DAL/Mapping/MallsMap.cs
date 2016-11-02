using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class MallsMap : EntityTypeConfiguration<Malls>
    {
        public MallsMap() { 
         this.ToTable("Malls");
            Property(m => m.Name).HasMaxLength(50).IsRequired();
            Property(m => m.EnName).HasMaxLength(50).IsRequired();
            Property(m => m.LetterKey).HasMaxLength(10).IsRequired().IsUnicode(false);
            Property(m => m.Logo).HasMaxLength(200).IsRequired().IsUnicode(false);
            Property(m => m.MaxDisc).HasMaxLength(30).IsRequired();
            Property(m => m.Intro).HasMaxLength(500).IsRequired();
            Property(m => m.Url).HasMaxLength(200).IsRequired().IsUnicode(false);
            Property(m => m.OurUrl).HasMaxLength(300).IsRequired().IsUnicode(false);
            Property(m => m.Detail).HasColumnType("text").IsRequired();
            Property(m => m.Matter).HasColumnType("text").IsRequired();
            HasRequired(x => x.MallType).WithMany(x => x.Malls).HasForeignKey(bc => bc.MallTypeId);
        }
    }
    public class MallTypeMap : EntityTypeConfiguration<MallType>
    {
        public MallTypeMap()
        {
            this.ToTable("MallType");
            Property(mm => mm.Name).HasMaxLength(30).IsRequired();
        }
    }
}
