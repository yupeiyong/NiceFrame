/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.IRepository.SystemSecurity;
using NFine.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Common;
using Nice.Common.Extend;
using Nice.Common.Json;
using Nice.Domain.Entity.SystemSecurity;


namespace NFine.Application.SystemSecurity
{
    public class DbBackupApp
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
            dbBackupBaseEntity.F_Id = Common.GuId();
            dbBackupBaseEntity.F_EnabledMark = true;
            dbBackupBaseEntity.F_BackupTime = DateTime.Now;
            service.ExecuteDbBackup(dbBackupBaseEntity);
        }
    }
}
