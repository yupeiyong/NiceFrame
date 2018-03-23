using System.Web.Mvc;
using Nice.WebPc.Areas.ExampleManage.Controllers;


namespace Nice.WebPc.Areas.ExampleManage
{
    public class ExampleManageAreaRegistration : AreaRegistration
    {
        public override string AreaName => "ExampleManage";


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                AreaName + "_Default",
                AreaName + "/{controller}/{action}/{id}",
                new { area = AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
                new [] { typeof(BarCodeController).Namespace }
            );
        }
    }
}
