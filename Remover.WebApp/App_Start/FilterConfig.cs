using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Winner.Mvc.Audit;

namespace Remover.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthRightAttribute());
            filters.Add(new AdminAuditAttribute());
        }
    }
}
