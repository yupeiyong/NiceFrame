using System.Collections.Generic;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Repository.IRepository.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetailBaseEntity>
    {
        List<ItemsDetailBaseEntity> GetItemList(string enCode);
    }
}
