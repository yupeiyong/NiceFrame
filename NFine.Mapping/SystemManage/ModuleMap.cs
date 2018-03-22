using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class ModuleMap : EntityTypeConfiguration<ModuleBaseEntity>
    {
        public ModuleMap()
        {
            this.ToTable("Sys_Module");
            this.HasKey(t => t.F_Id);
        }
    }
}
