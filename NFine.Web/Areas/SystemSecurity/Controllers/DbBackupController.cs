using System.Web.Mvc;
using Nice.Common.File;
using Nice.Common.Json;
using Nice.Domain.Entity.SystemSecurity;
using Nice.Service.SystemSecurity;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemSecurity.Controllers
{
    public class DbBackupController : Nice.WebPc.Handler.ControllerBase
    {
        private DbBackupService _dbBackupService = new DbBackupService();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string queryJson)
        {
            var data = _dbBackupService.GetList(queryJson);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DbBackupBaseEntity dbBackupBaseEntity)
        {
            dbBackupBaseEntity.F_FilePath = Server.MapPath("~/Resource/DbBackup/" + dbBackupBaseEntity.F_FileName + ".bak");
            dbBackupBaseEntity.F_FileName = dbBackupBaseEntity.F_FileName + ".bak";
            _dbBackupService.SubmitForm(dbBackupBaseEntity);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _dbBackupService.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        public void DownloadBackup(string keyValue)
        {
            var data = _dbBackupService.GetForm(keyValue);
            string filename = Server.UrlDecode(data.F_FileName);
            string filepath = Server.MapPath(data.F_FilePath);
            if (FileDownHelper.FileExists(filepath))
            {
                FileDownHelper.DownLoadold(filepath, filename);
            }
        }
    }
}
