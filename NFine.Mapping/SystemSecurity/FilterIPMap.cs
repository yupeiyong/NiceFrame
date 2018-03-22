using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemSecurity;


namespace Nice.Mapping.SystemSecurity
{
    public class FilterIpMap : EntityTypeConfiguration<FilterIpBaseEntity>
    {
        public FilterIpMap()
        {
            this.ToTable("Sys_FilterIP");
            this.HasKey(t => t.F_Id);
        }
    }
}
