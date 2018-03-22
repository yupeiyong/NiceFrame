using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemSecurity;


namespace Nice.Mapping.SystemSecurity
{
    public class LogMap : EntityTypeConfiguration<LogBaseEntity>
    {
        public LogMap()
        {
            this.ToTable("Sys_Log");
            this.HasKey(t => t.F_Id);
        }
    }
}
