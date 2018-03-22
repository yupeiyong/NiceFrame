/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using System.Collections.Generic;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Domain.IRepository.SystemManage
{
    public interface IRoleRepository : IRepositoryBase<RoleBaseEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(RoleBaseEntity roleBaseEntity, List<RoleAuthorizeBaseEntity> roleAuthorizeEntitys, string keyValue);
    }
}
