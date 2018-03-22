using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;


namespace Nice.Service.SystemManage
{
    public class ItemsService
    {
        private IItemsRepository service = new ItemsRepository();

        public List<ItemsBaseEntity> GetList()
        {
            return service.Queryable().ToList();
        }
        public ItemsBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.Queryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(ItemsBaseEntity itemsBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsBaseEntity.Modify(keyValue);
                service.Update(itemsBaseEntity);
            }
            else
            {
                itemsBaseEntity.Create();
                service.Insert(itemsBaseEntity);
            }
        }
    }
}
