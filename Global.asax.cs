using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebSalt.Models;

namespace WebSalt
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected String SqlConnectionString { get; set; }
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            using (var context = new HotarariContext())
                SqlConnectionString = context.Database.Connection.ConnectionString;
            if (!String.IsNullOrEmpty(SqlConnectionString.ToString()))
                SqlDependency.Start(SqlConnectionString.ToString());
        }

        protected void Application_End()
        {
            if (!String.IsNullOrEmpty(SqlConnectionString.ToString()))
                SqlDependency.Start(SqlConnectionString.ToString());
        }
    }
}
