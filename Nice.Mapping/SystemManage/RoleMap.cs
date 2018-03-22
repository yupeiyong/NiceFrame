using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class RoleMap : EntityTypeConfiguration<RoleBaseEntity>
    {
        public RoleMap()
        {
            this.ToTable("Sys_Role");
            this.HasKey(t => t.F_Id);
        }
    }
}
