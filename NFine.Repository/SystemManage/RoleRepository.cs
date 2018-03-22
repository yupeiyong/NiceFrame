using System.Collections.Generic;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;


namespace Nice.Repository.SystemManage
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
