/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.IRepository.SystemSecurity;
using NFine.Repository.SystemSecurity;
using Nice.Common.File;
using Nice.Data.Extensions;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemSecurity;


namespace NFine.Repository.SystemSecurity
{
    public class DbBackupRepository : RepositoryBase<DbBackupBaseEntity>, IDbBackupRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                var dbBackupEntity = db.FindEntity<DbBackupBaseEntity>(keyValue);
                if (dbBackupEntity != null)
                {
                    FileHelper.DeleteFile(dbBackupEntity.F_FilePath);
                }
                db.Delete<DbBackupBaseEntity>(dbBackupEntity);
                db.Commit();
            }
        }
        public void ExecuteDbBackup(DbBackupBaseEntity dbBackupBaseEntity)
        {
            DbHelper.ExecuteSqlCommand(string.Format("backup database {0} to disk ='{1}'", dbBackupBaseEntity.F_DbName, dbBackupBaseEntity.F_FilePath));
            dbBackupBaseEntity.F_FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupBaseEntity.F_FilePath));
            dbBackupBaseEntity.F_FilePath = "/Resource/DbBackup/" + dbBackupBaseEntity.F_FileName;
            this.Insert(dbBackupBaseEntity);
        }
    }
}
