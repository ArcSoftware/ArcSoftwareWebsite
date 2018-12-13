using System;
using System.Reflection;
using System.Web.Http;
using log4net;

namespace ArcSoftware.Controllers
{
    public class ApiControllerBase : ApiController
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private void LogException(Exception exception)
        {
            _logger.Error(exception.Message, exception);
        }
    }
}