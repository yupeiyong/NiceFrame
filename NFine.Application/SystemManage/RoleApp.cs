/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System.Collections.Generic;
using System.Linq;
using Nice.Common;
using Nice.Common.Extend;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Application.SystemManage
{
    public class RoleApp
    {
        private IRoleRepository service = new RoleRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<RoleBaseEntity> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<RoleBaseEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
                expression = expression.Or(t => t.F_EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.F_Category == 1);
            return service.Queryable(expression).OrderBy(t => t.F_SortCode).ToList();
        }
        public RoleBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(RoleBaseEntity roleBaseEntity, string[] permissionIds, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleBaseEntity.F_Id = keyValue;
            }
            else
            {
                roleBaseEntity.F_Id = Common.GuId();
            }
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            List<RoleAuthorizeBaseEntity> roleAuthorizeEntitys = new List<RoleAuthorizeBaseEntity>();
            foreach (var itemId in permissionIds)
            {
                RoleAuthorizeBaseEntity roleAuthorizeBaseEntity = new RoleAuthorizeBaseEntity();
                roleAuthorizeBaseEntity.F_Id = Common.GuId();
                roleAuthorizeBaseEntity.F_ObjectType = 1;
                roleAuthorizeBaseEntity.F_ObjectId = roleBaseEntity.F_Id;
                roleAuthorizeBaseEntity.F_ItemId = itemId;
                if (moduledata.Find(t => t.F_Id == itemId) != null)
                {
                    roleAuthorizeBaseEntity.F_ItemType = 1;
                }
                if (buttondata.Find(t => t.F_Id == itemId) != null)
                {
                    roleAuthorizeBaseEntity.F_ItemType = 2;
                }
                roleAuthorizeEntitys.Add(roleAuthorizeBaseEntity);
            }
            service.SubmitForm(roleBaseEntity, roleAuthorizeEntitys, keyValue);
        }
    }
}
