using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    
    public partial class FavoriteMap : EntityTypeConfiguration<Favorite>
    {
        public FavoriteMap()
        {
            this.ToTable("Favorites");

            HasRequired(x => x.Users).WithMany(x => x.Favorites).HasForeignKey(bc => bc.UsersId);
            HasRequired(x => x.Products).WithMany(x => x.Favorites).HasForeignKey(bc => bc.ProductsId);
        }

    }
}
