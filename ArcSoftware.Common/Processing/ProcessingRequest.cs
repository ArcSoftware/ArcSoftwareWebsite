using System.IO;
using ArcSoftware.Common.Enums;

namespace ArcSoftware.Common.Processing
{
    public class ProcessingRequest<TModel>
    {
        public TModel Item { get; set; }
        public FileStream File { get; set; }
        public ActionType ActionType { get; set; }
    }
}