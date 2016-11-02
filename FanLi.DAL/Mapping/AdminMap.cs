using FanLi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.DAL.Mapping
{
    public partial class AdminMap : EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            this.ToTable("Admin"); 
            HasRequired(x => x.AdminRole).WithMany(x => x.Admins).HasForeignKey(bc => bc.AdminRoleID); 
        }
         
    }
    public partial class AdminRoleMap : EntityTypeConfiguration<AdminRole>
    {
        public AdminRoleMap()
        {
            this.ToTable("AdminRole");
            
        }

    }
    public partial class AdminFunctionMap : EntityTypeConfiguration<AdminFunction>
    {
        public AdminFunctionMap()
        {
            this.ToTable("AdminFunction");

        }

    }
}
