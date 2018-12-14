using System.Web.Http;

namespace ArcSoftware.App_Start
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal static class WebApiConfig
    {
        internal static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}