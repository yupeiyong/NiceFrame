using System;
using System.Web.Mvc;
using NFine.Application;
using NFine.Application.SystemManage;
using NFine.Application.SystemSecurity;
using NFine.Code;
using Nice.Common;
using Nice.Common.Extend;
using Nice.Common.Json;
using Nice.Common.Net;
using Nice.Common.Operator;
using Nice.Common.Security;
using Nice.Domain.Entity.SystemManage;
using Nice.Domain.Entity.SystemSecurity;
using Nice.WebPc.Handler;


namespace Nice.WebPc.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new LogBaseEntity
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            LogBaseEntity logBaseEntity = new LogBaseEntity();
            logBaseEntity.F_ModuleName = "系统登录";
            logBaseEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                if (Session["nfine_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["nfine_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                UserBaseEntity userBaseEntity = new UserApp().CheckLogin(username, password);
                if (userBaseEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userBaseEntity.F_Id;
                    operatorModel.UserCode = userBaseEntity.F_Account;
                    operatorModel.UserName = userBaseEntity.F_RealName;
                    operatorModel.CompanyId = userBaseEntity.F_OrganizeId;
                    operatorModel.DepartmentId = userBaseEntity.F_DepartmentId;
                    operatorModel.RoleId = userBaseEntity.F_RoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DesEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userBaseEntity.F_Account == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logBaseEntity.F_Account = userBaseEntity.F_Account;
                    logBaseEntity.F_NickName = userBaseEntity.F_RealName;
                    logBaseEntity.F_Result = true;
                    logBaseEntity.F_Description = "登录成功";
                    new LogApp().WriteDbLog(logBaseEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logBaseEntity.F_Account = username;
                logBaseEntity.F_NickName = username;
                logBaseEntity.F_Result = false;
                logBaseEntity.F_Description = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logBaseEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
