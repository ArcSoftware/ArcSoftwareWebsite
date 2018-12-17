using System;
using System.Collections.Generic;
using ArcSoftware.Api.Processors;
using ArcSoftware.Common.Enums;
using ArcSoftware.Data.Models;
using Autofac;

namespace ArcSoftware.Api.DIModules
{
    internal class ProcessorModule : Module
    {
        private readonly Dictionary<Tuple<Type, ActionType>, Type> _processorDictionary = new Dictionary<Tuple<Type, ActionType>, Type>();

        protected override void Load(ContainerBuilder builder)
        {
            // Setup the processor dictionaries
            BuildDictionaries();

            // Register the ProcessorFactory with the configured dictionaries.
            builder.RegisterType<ProcessorFactory>()
                .As<IProcessorFactory>()
                .WithParameter(new TypedParameter(typeof(Dictionary<Tuple<Type, ActionType>, Type>), _processorDictionary))
                .InstancePerDependency();
        }

        private void BuildDictionaries()
        {
            // Soundboard Processor per actiontype
            _processorDictionary.Add(Tuple.Create(typeof(QuakeSoundModel), ActionType.Play), typeof(QuakeSoundProcessor));
        }
    }
}
