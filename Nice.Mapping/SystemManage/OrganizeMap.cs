using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class OrganizeMap : EntityTypeConfiguration<OrganizeBaseEntity>
    {
        public OrganizeMap()
        {
            this.ToTable("Sys_Organize");
            this.HasKey(t => t.F_Id);
        }
    }
}
