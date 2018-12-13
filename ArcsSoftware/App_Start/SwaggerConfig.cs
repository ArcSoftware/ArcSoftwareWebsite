using System.Web.Http;
using Swashbuckle.Application;

namespace ArcSoftware.App_Start
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal static class SwaggerConfig
    {
        internal static void Register(HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "ArcSoftware.Api");
                    c.DescribeAllEnumsAsStrings();
                })
                .EnableSwaggerUi(c => c.DisableValidator());
        }
    }
}