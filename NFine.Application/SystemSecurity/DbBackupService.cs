using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Common.Extend;
using Nice.Common.Json;
using Nice.Domain.Entity.SystemSecurity;
using Nice.Repository.IRepository.SystemSecurity;
using Nice.Repository.SystemSecurity;


namespace Nice.Service.SystemSecurity
{
    public class DbBackupService
    {
        private IDbBackupRepository service = new DbBackupRepository();

        public List<DbBackupBaseEntity> GetList(string queryJson)
        {
            var expression = ExtLinq.True<DbBackupBaseEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "DbName":  
                        expression = expression.And(t => t.F_DbName.Contains(keyword));
                        break;
                    case "FileName":
                        expression = expression.And(t => t.F_FileName.Contains(keyword));
                        break;
                }
            }
            return service.Queryable(expression).OrderByDescending(t => t.F_BackupTime).ToList();
        }
        public DbBackupBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(DbBackupBaseEntity dbBackupBaseEntity)
        {
            dbBackupBaseEntity.F_Id = Common.Common.GuId();
            dbBackupBaseEntity.F_EnabledMark = true;
            dbBackupBaseEntity.F_BackupTime = DateTime.Now;
            service.ExecuteDbBackup(dbBackupBaseEntity);
        }
    }
}
