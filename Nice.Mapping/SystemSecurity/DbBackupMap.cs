using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemSecurity;


namespace Nice.Mapping.SystemSecurity
{
    public class DbBackupMap : EntityTypeConfiguration<DbBackupBaseEntity>
    {
        public DbBackupMap()
        {
            this.ToTable("Sys_DbBackup");
            this.HasKey(t => t.F_Id);
        }
    }
}
