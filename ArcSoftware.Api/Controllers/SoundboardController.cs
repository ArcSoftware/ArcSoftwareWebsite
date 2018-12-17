using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using ArcSoftware.Api.Processors;
using ArcSoftware.Common.Enums;
using ArcSoftware.Data.Models;
using Swashbuckle.Swagger.Annotations;

namespace ArcSoftware.Api.Controllers
{
    [RoutePrefix("api/soundboard")]
    
    public class SoundboardController : ApiControllerBase
    {
        private readonly IProcessorFactory _processorFactory;

        /// <summary>
        /// Gets soundboard files by filename and optional variation.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="variation"></param>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("soundboard")]
        [SwaggerOperation("PlayQuakeSound")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<HttpResponseMessage> PlayQuakeSound([FromUri] string fileName, [FromUri] SoundVariation variation = SoundVariation.Male)
        {
            var model = new QuakeSoundModel(fileName, "Quake", StaticFileType.QuakeSound, variation);
  
            var result = await Get<QuakeSoundModel>(model, ActionType.Play);         
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/mp3");

            return result;
        }

        /// <summary>
        /// Gets static files by TModel and actionType.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="actionType"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> Get<TModel>(TModel model, ActionType actionType)
            where TModel : StaticFileModel
        {
            var result = new HttpResponseMessage();
            if (!ModelState.IsValid)
            {
                result.StatusCode = HttpStatusCode.BadRequest;
                return result;
            }

            try
            {
                var processor = _processorFactory.GetProcessor<TModel>(model, actionType);
                var request = await processor.Process(model, actionType);
                result.Content = new StreamContent(request.File); 

                return result;
            }

            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}