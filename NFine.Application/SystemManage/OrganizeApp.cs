/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Application.SystemManage
{
    public class OrganizeApp
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
