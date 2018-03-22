using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Mapping.SystemManage
{
    public class UserMap : EntityTypeConfiguration<UserBaseEntity>
    {
        public UserMap()
        {
            this.ToTable("Sys_User");
            this.HasKey(t => t.F_Id);
        }
    }
}
