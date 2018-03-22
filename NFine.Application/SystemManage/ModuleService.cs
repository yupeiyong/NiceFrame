using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;


namespace Nice.Service.SystemManage
{
    public class ModuleService
    {
        private IModuleRepository service = new ModuleRepository();

        public List<ModuleBaseEntity> GetList()
        {
            return service.Queryable().OrderBy(t => t.F_SortCode).ToList();
        }
        public ModuleBaseEntity GetForm(string keyValue)
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
        public void SubmitForm(ModuleBaseEntity moduleBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleBaseEntity.Modify(keyValue);
                service.Update(moduleBaseEntity);
            }
            else
            {
                moduleBaseEntity.Create();
                service.Insert(moduleBaseEntity);
            }
        }
    }
}
