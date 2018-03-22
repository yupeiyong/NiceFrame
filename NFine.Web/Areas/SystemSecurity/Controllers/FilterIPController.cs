using System.Web.Mvc;
using Nice.Common.Json;
using Nice.Domain.Entity.SystemSecurity;
using Nice.Service.SystemSecurity;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemSecurity.Controllers
{
    public class FilterIPController : Nice.WebPc.Handler.ControllerBase
    {
        private FilterIpService _filterIpService = new FilterIpService();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = _filterIpService.GetList(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _filterIpService.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FilterIpBaseEntity filterIpBaseEntity, string keyValue)
        {
            _filterIpService.SubmitForm(filterIpBaseEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _filterIpService.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
