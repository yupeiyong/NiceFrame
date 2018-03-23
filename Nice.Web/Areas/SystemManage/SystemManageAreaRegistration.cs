using System.Web.Mvc;
using System.Web.UI;
using Nice.WebPc.Areas.SystemManage.Controllers;


namespace Nice.WebPc.Areas.SystemManage
{
    public class SystemManageAreaRegistration : AreaRegistration
    {
        public override string AreaName => "SystemManage";


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              AreaName + "_Default",
              AreaName + "/{controller}/{action}/{id}",
              new { area = AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new[] { typeof(RoleController).Namespace }
            );
        }
    }
}
