/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.IRepository.SystemSecurity;
using NFine.Repository.SystemSecurity;
using System.Collections.Generic;
using System.Linq;
using Nice.Common.Extend;
using Nice.Domain.Entity.SystemSecurity;


namespace NFine.Application.SystemSecurity
{
    public class FilterIPApp
    {
        private IFilterIPRepository service = new FilterIPRepository();

        public List<FilterIpBaseEntity> GetList(string keyword)
        {
            var expression = ExtLinq.True<FilterIpBaseEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_StartIP.Contains(keyword));
            }
            return service.Queryable(expression).OrderByDescending(t => t.F_DeleteTime).ToList();
        }
        public FilterIpBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(FilterIpBaseEntity filterIpBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                filterIpBaseEntity.Modify(keyValue);
                service.Update(filterIpBaseEntity);
            }
            else
            {
                filterIpBaseEntity.Create();
                service.Insert(filterIpBaseEntity);
            }
        }
    }
}
