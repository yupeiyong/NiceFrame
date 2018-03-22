using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class RoleAuthorizeMap : EntityTypeConfiguration<RoleAuthorizeBaseEntity>
    {
        public RoleAuthorizeMap()
        {
            this.ToTable("Sys_RoleAuthorize");
            this.HasKey(t => t.F_Id);
        }
    }
}
