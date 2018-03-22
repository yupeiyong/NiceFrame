/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Common;
using Nice.Common.Extend;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Application.SystemManage
{
    public class ModuleButtonApp
    {
        private IModuleButtonRepository service = new ModuleButtonRepository();

        public List<ModuleButtonBaseEntity> GetList(string moduleId = "")
        {
            var expression = ExtLinq.True<ModuleButtonBaseEntity>();
            if (!string.IsNullOrEmpty(moduleId))
            {
                expression = expression.And(t => t.F_ModuleId == moduleId);
            }
            return service.Queryable(expression).OrderBy(t => t.F_SortCode).ToList();
        }
        public ModuleButtonBaseEntity GetForm(string keyValue)
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
        public void SubmitForm(ModuleButtonBaseEntity moduleButtonBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleButtonBaseEntity.Modify(keyValue);
                service.Update(moduleButtonBaseEntity);
            }
            else
            {
                moduleButtonBaseEntity.Create();
                service.Insert(moduleButtonBaseEntity);
            }
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<ModuleButtonBaseEntity> entitys = new List<ModuleButtonBaseEntity>();
            foreach (string item in ArrayId)
            {
                ModuleButtonBaseEntity moduleButtonBaseEntity = data.Find(t => t.F_Id == item);
                moduleButtonBaseEntity.F_Id = Common.GuId();
                moduleButtonBaseEntity.F_ModuleId = moduleId;
                entitys.Add(moduleButtonBaseEntity);
            }
            service.SubmitCloneButton(entitys);
        }
    }
}
