using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            this.ToTable("News");
            Property(n => n.Title).HasMaxLength(200).IsRequired();
            Property(n => n.Contents).HasColumnType("text").IsRequired();
        
             
        }
    }
}
