using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing.Constraints;

namespace ProvaAvonale.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              "Guid",
              "{controller}/{id}",
              new { controller = "Home", action = "Index", id = RouteParameter.Optional },
              new { id = new GuidRouteConstraint() }
           );
        }
    }
}
