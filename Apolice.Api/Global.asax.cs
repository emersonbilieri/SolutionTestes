using Apolice.Repository;
using Apolice.Service;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Apolice.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            DependencyResolver.SetResolver(
               new SimpleInjector.Integration.Web.Mvc.SimpleInjectorDependencyResolver(Ioc.SimpleInjectorContainer.RegisterServices()));

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(Ioc.SimpleInjectorContainer.RegisterServices());
                       
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
