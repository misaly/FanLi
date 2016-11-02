using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public class ProductsMap : EntityTypeConfiguration<Products>
    {
        public ProductsMap()
        {
            this.ToTable("Products");
            Property(p => p.proName).HasMaxLength(200).IsRequired();
            Property(p => p.Pic).IsUnicode(false).HasMaxLength(200);
            Property(p => p.Url).IsRequired();

            HasRequired(x => x.ProductType).WithMany(x => x.Products).HasForeignKey(bc => bc.ProductTypeId);
            HasRequired(x => x.Malls).WithMany(x => x.Products).HasForeignKey(bc => bc.MallsId);
        }
    }

    public class ProductTypeMap : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeMap()
        {
            this.ToTable("ProductType");
            Property(p => p.tpName).HasMaxLength(30).IsRequired();
            Property(p => p.tpIcon).HasMaxLength(200);  
        }
    }
}
