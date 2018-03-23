using System.Web.Mvc;


namespace Nice.WebPc.Areas.SystemManage
{
    public class SystemManageAreaRegistration : AreaRegistration
    {
        public override string AreaName => "SystemManage";


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "Nice.WebPc.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
