using ArcSoftware.Common.Enums;

namespace ArcSoftware.Api.Processors
{
    public interface IProcessorFactory
    {
        ProcessorBase<TModel> GetProcessor<TModel>(TModel model, ActionType actionType)
            where TModel : class;
    }
}