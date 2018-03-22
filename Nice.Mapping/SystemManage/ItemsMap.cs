using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class ItemsMap : EntityTypeConfiguration<ItemsBaseEntity>
    {
        public ItemsMap()
        {
            this.ToTable("Sys_Items");
            this.HasKey(t => t.F_Id);
        }
    }
}
