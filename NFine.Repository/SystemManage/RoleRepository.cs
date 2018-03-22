/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System.Collections.Generic;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<RoleBaseEntity>, IRoleRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<RoleBaseEntity>(t => t.F_Id == keyValue);
                db.Delete<RoleAuthorizeBaseEntity>(t => t.F_ObjectId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(RoleBaseEntity roleBaseEntity, List<RoleAuthorizeBaseEntity> roleAuthorizeEntitys, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(roleBaseEntity);
                }
                else
                {
                    roleBaseEntity.F_Category = 1;
                    db.Insert(roleBaseEntity);
                }
                db.Delete<RoleAuthorizeBaseEntity>(t => t.F_ObjectId == roleBaseEntity.F_Id);
                db.Insert(roleAuthorizeEntitys);
                db.Commit();
            }
        }
    }
}
