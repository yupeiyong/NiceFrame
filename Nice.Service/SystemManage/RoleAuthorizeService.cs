using System;
using System.Collections.Generic;
using System.Linq;
using Nice.Common.Cache;
using Nice.Common.Operator;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;
using Nice.ViewModel;


namespace Nice.Service.SystemManage
{
    public class RoleAuthorizeService
    {
        private IRoleAuthorizeRepository service = new RoleAuthorizeRepository();
        private ModuleService _moduleService = new ModuleService();
        private ModuleButtonService _moduleButtonService = new ModuleButtonService();

        public List<RoleAuthorizeBaseEntity> GetList(string ObjectId)
        {
            return service.Queryable(t => t.F_ObjectId == ObjectId).ToList();
        }
        public List<ModuleBaseEntity> GetMenuList(string roleId)
        {
            var data = new List<ModuleBaseEntity>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = _moduleService.GetList();
            }
            else
            {
                var moduledata = _moduleService.GetList();
                var authorizedata = service.Queryable(t => t.F_ObjectId == roleId && t.F_ItemType == 1).ToList();
                foreach (var item in authorizedata)
                {
                    ModuleBaseEntity moduleBaseEntity = moduledata.Find(t => t.F_Id == item.F_ItemId);
                    if (moduleBaseEntity != null)
                    {
                        data.Add(moduleBaseEntity);
                    }
                }
            }
            return data.OrderBy(t => t.F_SortCode).ToList();
        }
        public List<ModuleButtonBaseEntity> GetButtonList(string roleId)
        {
            var data = new List<ModuleButtonBaseEntity>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = _moduleButtonService.GetList();
            }
            else
            {
                var buttondata = _moduleButtonService.GetList();
                var authorizedata = service.Queryable(t => t.F_ObjectId == roleId && t.F_ItemType == 2).ToList();
                foreach (var item in authorizedata)
                {
                    ModuleButtonBaseEntity moduleButtonBaseEntity = buttondata.Find(t => t.F_Id == item.F_ItemId);
                    if (moduleButtonBaseEntity != null)
                    {
                        data.Add(moduleButtonBaseEntity);
                    }
                }
            }
            return data.OrderBy(t => t.F_SortCode).ToList();
        }
        public bool ActionValidate(string roleId, string moduleId, string action)
        {
            var authorizeurldata = new List<AuthorizeActionModel>();
            var cachedata = CacheFactory.Cache().GetCache<List<AuthorizeActionModel>>("authorizeurldata_" + roleId);
            if (cachedata == null)
            {
                var moduledata = _moduleService.GetList();
                var buttondata = _moduleButtonService.GetList();
                var authorizedata = service.Queryable(t => t.F_ObjectId == roleId).ToList();
                foreach (var item in authorizedata)
                {
                    if (item.F_ItemType == 1)
                    {
                        ModuleBaseEntity moduleBaseEntity = moduledata.Find(t => t.F_Id == item.F_ItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleBaseEntity.F_Id, F_UrlAddress = moduleBaseEntity.F_UrlAddress });
                    }
                    else if (item.F_ItemType == 2)
                    {
                        ModuleButtonBaseEntity moduleButtonBaseEntity = buttondata.Find(t => t.F_Id == item.F_ItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleButtonBaseEntity.F_ModuleId, F_UrlAddress = moduleButtonBaseEntity.F_UrlAddress });
                    }
                }
                CacheFactory.Cache().WriteCache(authorizeurldata, "authorizeurldata_" + roleId, DateTime.Now.AddMinutes(5));
            }
            else
            {
                authorizeurldata = cachedata;
            }
            authorizeurldata = authorizeurldata.FindAll(t => t.F_Id.Equals(moduleId));
            foreach (var item in authorizeurldata)
            {
                if (!string.IsNullOrEmpty(item.F_UrlAddress))
                {
                    string[] url = item.F_UrlAddress.Split('?');
                    if (item.F_Id == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
