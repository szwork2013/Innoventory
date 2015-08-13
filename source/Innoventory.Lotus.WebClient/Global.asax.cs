using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector.Extensions;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using Innoventory.Lotus.Core;
using Innoventory.Lotus.Bootsraper;
using System.Web.Http;

namespace Innoventory.Lotus.WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
            

            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            CompositionContainer container = DependencyContainer.Initialize(catalog);

            GlobalConfiguration.Configuration.DependencyResolver = new MefApiDependencyResolver(container);
            DependencyResolver.SetResolver(new MefDependencyResolver(container));
        }
    }
}
