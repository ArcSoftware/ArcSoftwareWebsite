using System.Reflection;
using System.Web.Http;
using ArcSoftware.App_Start.DIModules;
using Autofac;
using Autofac.Integration.WebApi;

namespace ArcSoftware.Api
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal static class AutofacConfig
    {
        internal static void Register(ContainerBuilder builder, HttpConfiguration config)
        {
            builder.RegisterModule(new LoggingModule());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var resolver = new AutofacWebApiDependencyResolver(builder.Build());
            config.DependencyResolver = resolver;
        }
    }
}