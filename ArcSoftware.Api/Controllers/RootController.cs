using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArcSoftware.Controllers
{
    public class RootController : ApiController
    {
        /// <summary>
        /// Health Check
        /// </summary>
        /// <returns>Ok</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("")]
        [ApiExplorerSettings(IgnoreApi = true)] // No Swagger
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("The API is up!"),
                StatusCode = HttpStatusCode.OK,             
            };
        }
    }
}
