using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using ArcSoftware.Common.Models;
using log4net;

namespace ArcSoftware.Api.Controllers
{
    public class ApiControllerBase : ApiController
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected HttpResponseMessage HandleException(Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, 
            string detail = null, IEnumerable<string> messages = null, string source = null, bool logEvent = true)
        {
            if (logEvent) LogException(exception);

            source = source ?? exception.Source;
            var exceptionContent = new ExceptionResponseModel(detail, messages, source);

            return Request.CreateResponse(statusCode, exceptionContent);
        }

        private void LogException(Exception exception)
        {
            _logger.Error(exception.Message, exception);
        }
    }
}