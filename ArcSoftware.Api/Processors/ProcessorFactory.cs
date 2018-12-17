using System;
using System.Collections.Generic;
using ArcSoftware.Common.Enums;

namespace ArcSoftware.Api.Processors
{
    public class ProcessorFactory : IProcessorFactory
    {
        private readonly Dictionary<Tuple<Type, ActionType>, Type> _processorDictionary;

        public ProcessorFactory(Dictionary<Tuple<Type, ActionType>, Type> processorDictionary)
        {
            _processorDictionary = processorDictionary;
        }

        public ProcessorBase<TModel> GetProcessor<TModel>(TModel model, ActionType actionType) where TModel : class
        {
            var processorType = _processorDictionary[Tuple.Create(typeof(TModel), actionType)];
            return Activator.CreateInstance(processorType) as ProcessorBase<TModel>;
        }
    }
}