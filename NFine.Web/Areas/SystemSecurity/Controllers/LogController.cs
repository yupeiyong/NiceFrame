using System.Web.Mvc;
using Nice.Common.Json;
using Nice.Common.Web;
using Nice.Service.SystemSecurity;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemSecurity.Controllers
{
    public class LogController : Nice.WebPc.Handler.ControllerBase
    {
        private LogService _logService = new LogService();

        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = _logService.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            _logService.RemoveLog(keepTime);
            return Success("清空成功。");
        }
    }
}
