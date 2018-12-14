using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using ArcSoftware.Controllers;
using Swashbuckle.Swagger.Annotations;

namespace ArcSoftware.Api.Controllers
{
    [RoutePrefix("api/soundboard")]
    public class SoundboardController : ApiControllerBase
    {
        /// <summary>
        /// Gets soundboard files by the identifier.
        /// </summary>
        /// <param name="fileId">The file identifier.</param>
        [HttpGet]
        [Route("{fileId}")]
        [SwaggerOperation("fileId")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<HttpResponseMessage> GetByFileId([FromUri] string fileId)
        {
            return await Get(fileId: fileId);
        }

        /// <summary>
        /// Gets Files by id.
        /// </summary>
        /// <param name="fileId">The file identifier</param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> Get(string fileId)
        {
            var result = new HttpResponseMessage();
            if (fileId == null)
            {
                result.StatusCode = HttpStatusCode.BadRequest;
                return result;
            }

            try
            {
                result.Content = new StreamContent(null); //Need to get File from processor 
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/mp3");
                return result;
            }

            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}