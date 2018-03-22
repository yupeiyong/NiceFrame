using System.Web.Mvc;
using Nice.WebPc.Handler;


namespace Nice.WebPc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandlerErrorAttribute());
        }
    }
}