using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
   
    public class LogisticalsMap : EntityTypeConfiguration<Logistical>
    {
        public LogisticalsMap()
        {
            this.ToTable("Logisticals");
            Property(m => m.Name).HasMaxLength(50).IsRequired();
            Property(m => m.Icon).HasMaxLength(200).IsRequired().IsUnicode(false);
            Property(m => m.Url).HasMaxLength(200).IsRequired().IsUnicode(false);
            Property(m => m.Detail).HasColumnType("text").IsRequired();
        }
    }
}
