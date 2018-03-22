using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class ModuleButtonMap : EntityTypeConfiguration<ModuleButtonBaseEntity>
    {
        public ModuleButtonMap()
        {
            this.ToTable("Sys_ModuleButton");
            this.HasKey(t => t.F_Id);
        }
    }
}
