using System.Threading.Tasks;
using ArcSoftware.Common.Enums;
using ArcSoftware.Common.Processing;

namespace ArcSoftware.Api.Processors
{
    public abstract class ProcessorBase<TModel>
    where TModel : class
    {
        public abstract Task<ProcessingRequest<TModel>> Process(TModel model, ActionType actionType);
    }
}