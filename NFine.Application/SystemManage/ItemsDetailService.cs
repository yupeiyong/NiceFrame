using System.Collections.Generic;
using System.Linq;
using Nice.Common.Extend;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;


namespace Nice.Service.SystemManage
{
    public class ItemsDetailService
    {
        private IItemsDetailRepository service = new ItemsDetailRepository();

        public List<ItemsDetailBaseEntity> GetList(string itemId = "", string keyword = "")
        {
            var expression = ExtLinq.True<ItemsDetailBaseEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.F_ItemId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_ItemName.Contains(keyword));
                expression = expression.Or(t => t.F_ItemCode.Contains(keyword));
            }
            return service.Queryable(expression).OrderBy(t => t.F_SortCode).ToList();
        }
        public List<ItemsDetailBaseEntity> GetItemList(string enCode)
        {
            return service.GetItemList(enCode);
        }
        public ItemsDetailBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(ItemsDetailBaseEntity itemsDetailBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsDetailBaseEntity.Modify(keyValue);
                service.Update(itemsDetailBaseEntity);
            }
            else
            {
                itemsDetailBaseEntity.Create();
                service.Insert(itemsDetailBaseEntity);
            }
        }
    }
}
