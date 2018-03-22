using System.Web.Mvc;
using NFine.Application.SystemSecurity;
using Nice.Common.File;
using Nice.Common.Json;
using Nice.Domain.Entity.SystemSecurity;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemSecurity.Controllers
{
    public class DbBackupController : Nice.WebPc.Handler.ControllerBase
    {
        private DbBackupApp dbBackupApp = new DbBackupApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string queryJson)
        {
            var data = dbBackupApp.GetList(queryJson);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DbBackupBaseEntity dbBackupBaseEntity)
        {
            dbBackupBaseEntity.F_FilePath = Server.MapPath("~/Resource/DbBackup/" + dbBackupBaseEntity.F_FileName + ".bak");
            dbBackupBaseEntity.F_FileName = dbBackupBaseEntity.F_FileName + ".bak";
            dbBackupApp.SubmitForm(dbBackupBaseEntity);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            dbBackupApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        public void DownloadBackup(string keyValue)
        {
            var data = dbBackupApp.GetForm(keyValue);
            string filename = Server.UrlDecode(data.F_FileName);
            string filepath = Server.MapPath(data.F_FilePath);
            if (FileDownHelper.FileExists(filepath))
            {
                FileDownHelper.DownLoadold(filepath, filename);
            }
        }
    }
}
