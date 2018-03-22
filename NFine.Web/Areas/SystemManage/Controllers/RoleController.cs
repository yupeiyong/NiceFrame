using System.Web.Mvc;
using Nice.Common.Json;
using Nice.Domain.Entity.SystemManage;
using Nice.Service.SystemManage;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemManage.Controllers
{
    public class RoleController : Nice.WebPc.Handler.ControllerBase
    {
        private RoleService _roleService = new RoleService();
        private RoleAuthorizeService _roleAuthorizeService = new RoleAuthorizeService();
        private ModuleService _moduleService = new ModuleService();
        private ModuleButtonService _moduleButtonService = new ModuleButtonService();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = _roleService.GetList(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _roleService.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(RoleBaseEntity roleBaseEntity, string permissionIds, string keyValue)
        {
            _roleService.SubmitForm(roleBaseEntity, permissionIds.Split(','), keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _roleService.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
