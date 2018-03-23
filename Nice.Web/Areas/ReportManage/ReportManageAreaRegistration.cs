using System.Web.Mvc;
using Nice.WebPc.Areas.ReportManage.Controllers;


namespace Nice.WebPc.Areas.ReportManage
{
    public class ReportManageAreaRegistration : AreaRegistration
    {
        public override string AreaName => "ReportManage";


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              AreaName + "_Default",
              AreaName + "/{controller}/{action}/{id}",
              new { area = AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new[] { typeof(EchartsController).Namespace }
            );
        }
    }
}
