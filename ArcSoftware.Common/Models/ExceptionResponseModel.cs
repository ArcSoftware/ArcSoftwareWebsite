using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArcSoftware.Common.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ExceptionResponseModel
    {
        public ExceptionResponseModel(string detail = null, IEnumerable<string> messages = null, string source = null)
        {
            Detail = detail ?? "An error has occured while processing request";
            MoreDetails = messages;
            Source = source ?? "Unknown";
        }

        public string Detail { get; set; }

        public IEnumerable<string> MoreDetails { get; set; }

        public string Source { get; set; }
    }
}
