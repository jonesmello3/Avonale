using ProvaAvonale.CrossCutting.Mappers;
using ProvaAvonale.CrossCutting.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProvaAvonale.WebApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            Container container = new Container();
            SimpleInjectorContainer.Register(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //var registeredControllerTypes = SimpleInjectorMvcExtensions.GetControllerTypesToRegister(container, Assembly.GetExecutingAssembly());
            //container.RegisterMvcControllers(GlobalConfiguration.Configuration);
        }
    }
}
