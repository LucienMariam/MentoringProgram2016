using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogger logger;

        public MvcApplication()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }

        protected void Application_Start()
        {
            this.logger.Info("Application has started!");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var loginCounter = new PerformanceCounter("High Category", "PerformoCounter", false))
            {
                loginCounter.RawValue = 0;
            }
        }

        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
            logger.Error(ex.ToString());
        }
    }
}
