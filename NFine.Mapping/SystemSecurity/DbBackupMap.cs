/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemSecurity;


namespace NFine.Mapping.SystemSecurity
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
