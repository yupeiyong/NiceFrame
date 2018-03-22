﻿/*******************************************************************************
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
    public class ItemsApp
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
