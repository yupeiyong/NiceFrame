using System.Collections.Generic;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Repository.IRepository.SystemManage
{
    public interface IRoleRepository : IRepositoryBase<RoleBaseEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(RoleBaseEntity roleBaseEntity, List<RoleAuthorizeBaseEntity> roleAuthorizeEntitys, string keyValue);
    }
}
