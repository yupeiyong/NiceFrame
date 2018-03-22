using System.Web.Mvc;
using Nice.Common.Json;
using Nice.Common.Web;
using Nice.Domain.Entity.SystemManage;
using Nice.Service.SystemManage;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Areas.SystemManage.Controllers
{
    public class UserController : Handler.ControllerBase
    {
        private UserService _userService = new UserService();
        private UserLogOnService _userLogOnService = new UserLogOnService();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _userService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _userService.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(UserBaseEntity userBaseEntity, UserLogOnBaseEntity userLogOnBaseEntity, string keyValue)
        {
            _userService.SubmitForm(userBaseEntity, userLogOnBaseEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            _userService.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        [HttpGet]
        public ActionResult RevisePassword()
        {
            return View();
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRevisePassword(string userPassword, string keyValue)
        {
            _userLogOnService.RevisePassword(userPassword, keyValue);
            return Success("重置密码成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DisabledAccount(string keyValue)
        {
            UserBaseEntity userBaseEntity = new UserBaseEntity();
            userBaseEntity.F_Id = keyValue;
            userBaseEntity.F_EnabledMark = false;
            _userService.UpdateForm(userBaseEntity);
            return Success("账户禁用成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult EnabledAccount(string keyValue)
        {
            UserBaseEntity userBaseEntity = new UserBaseEntity();
            userBaseEntity.F_Id = keyValue;
            userBaseEntity.F_EnabledMark = true;
            _userService.UpdateForm(userBaseEntity);
            return Success("账户启用成功。");
        }

        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }
    }
}
