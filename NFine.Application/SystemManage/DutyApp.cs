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
using Nice.Common.Extend;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Application.SystemManage
{
    public class DutyApp
    {
        private IRoleRepository service = new RoleRepository();

        public List<RoleBaseEntity> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<RoleBaseEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
                expression = expression.Or(t => t.F_EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.F_Category == 2);
            return service.Queryable(expression).OrderBy(t => t.F_SortCode).ToList();
        }
        public RoleBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(RoleBaseEntity roleBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleBaseEntity.Modify(keyValue);
                service.Update(roleBaseEntity);
            }
            else
            {
                roleBaseEntity.Create();
                roleBaseEntity.F_Category = 2;
                service.Insert(roleBaseEntity);
            }
        }
    }
}
