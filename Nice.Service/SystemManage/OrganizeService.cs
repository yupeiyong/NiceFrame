using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;


namespace Nice.Service.SystemManage
{
    public class OrganizeService
    {
        private IOrganizeRepository service = new OrganizeRepository();

        public List<OrganizeBaseEntity> GetList()
        {
            return service.Queryable().OrderBy(t => t.F_CreatorTime).ToList();
        }
        public OrganizeBaseEntity GetForm(string keyValue)
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
        public void SubmitForm(OrganizeBaseEntity organizeBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeBaseEntity.Modify(keyValue);
                service.Update(organizeBaseEntity);
            }
            else
            {
                organizeBaseEntity.Create();
                service.Insert(organizeBaseEntity);
            }
        }
    }
}
