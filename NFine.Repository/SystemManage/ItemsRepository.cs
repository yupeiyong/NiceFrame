/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Repository.SystemManage
{
    public class ItemsRepository : RepositoryBase<ItemsBaseEntity>, IItemsRepository
    {

    }
}
