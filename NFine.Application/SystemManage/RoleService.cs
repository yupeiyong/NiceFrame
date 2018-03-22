using System.Collections.Generic;
using System.Linq;
using Nice.Common.Extend;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;


namespace Nice.Service.SystemManage
{
    public class RoleService
    {
        private IRoleRepository service = new RoleRepository();
        private ModuleService _moduleService = new ModuleService();
        private ModuleButtonService _moduleButtonService = new ModuleButtonService();

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
                roleBaseEntity.F_Id = Common.Common.GuId();
            }
            var moduledata = _moduleService.GetList();
            var buttondata = _moduleButtonService.GetList();
            List<RoleAuthorizeBaseEntity> roleAuthorizeEntitys = new List<RoleAuthorizeBaseEntity>();
            foreach (var itemId in permissionIds)
            {
                RoleAuthorizeBaseEntity roleAuthorizeBaseEntity = new RoleAuthorizeBaseEntity();
                roleAuthorizeBaseEntity.F_Id = Common.Common.GuId();
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
