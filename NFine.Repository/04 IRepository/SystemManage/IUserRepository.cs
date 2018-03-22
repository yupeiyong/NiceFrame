/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Domain.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserBaseEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(UserBaseEntity userBaseEntity, UserLogOnBaseEntity userLogOnBaseEntity, string keyValue);
    }
}
