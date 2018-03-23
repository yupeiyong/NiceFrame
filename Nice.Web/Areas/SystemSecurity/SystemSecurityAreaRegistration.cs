using System.Web.Mvc;
using Nice.WebPc.Areas.SystemSecurity.Controllers;


namespace Nice.WebPc.Areas.SystemSecurity
{
    public class SystemSecurityAreaRegistration : AreaRegistration
    {
        public override string AreaName => "SystemSecurity";


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                 AreaName + "_Default",
                 AreaName + "/{controller}/{action}/{id}",
                 new { area = AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { typeof(LogController).Namespace }
           );
        }
    }
}
