using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Providers.Behavior;
using Winner.Framework.Utils;
using Winner.Mvc.Audit;
using Winner.Platform.MVC.Provider;

namespace Remover.WebAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        const string APPID = "cloudm";
        const string SECRET = "f0784c719c96466b8ffda64134f6da1b";
        const string SCOPE = "basic_api";
        const string UUID_KEY = "f32447e62d0c470082411295a269d625";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ProviderManager.RegisterAccountProvider(new UserAccountProvider());
            ProviderManager.RegisterRightProvider(new RightProvider());
            ProviderManager.RegisterLoginProvider(new OAuthLoginProvider(APPID, SECRET, SCOPE, UUID_KEY, null));
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            Log.Error(ex); //记录日志信息  
        }
    }
}
