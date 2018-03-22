using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class UserLogOnMap : EntityTypeConfiguration<UserLogOnBaseEntity>
    {
        public UserLogOnMap()
        {
            this.ToTable("Sys_UserLogOn");
            this.HasKey(t => t.F_Id);
        }
    }
}
