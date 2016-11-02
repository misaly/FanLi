using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class VideoMap : EntityTypeConfiguration<Video> 
    {
        public VideoMap()
        {
            this.ToTable("Videos");
            //HasRequired(x => x.).WithMany(x => x.Malls).HasForeignKey(bc => bc.MallTypeId);
            Property(v => v.Src).IsRequired().HasMaxLength(300).IsUnicode();
            Property(v => v.Img).HasMaxLength(200).IsUnicode();
            Property(v => v.Title).HasMaxLength(200);
        }
    }

    public class VideoCommentMap : EntityTypeConfiguration<VideoComment>
    {
        public VideoCommentMap()
        {
            this.ToTable("VideoComment");
            Property(vc => vc.Comment).IsRequired().HasMaxLength(1000);
            HasRequired(x => x.Video).WithMany(x => x.VideoComment).HasForeignKey(bc => bc.VideoId);
            HasRequired(x => x.Users).WithMany(x => x.VideoComment).HasForeignKey(bc => bc.UsersId);
        }
    }

    public class VideoZanMap : EntityTypeConfiguration<VideoZan>
    {
        public VideoZanMap()
        {
            this.ToTable("VideoZan");
            HasRequired(x => x.Video).WithMany(x => x.VideoZan).HasForeignKey(bc => bc.VideoId);
            HasRequired(x => x.Users).WithMany(x => x.VideoZan).HasForeignKey(bc => bc.UsersId);
        }
    }
}
