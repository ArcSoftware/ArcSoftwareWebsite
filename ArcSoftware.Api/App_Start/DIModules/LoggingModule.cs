using System.IO;
using System.Reflection;
using System.Xml;
using ArcSoftware.Api;
using Autofac;
using Module = Autofac.Module;

namespace ArcSoftware.App_Start.DIModules
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal class LoggingModule : Module
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(typeof(Program));

        protected override void Load(ContainerBuilder builder)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = log4net.LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            Log.Info("Application - Main is invoked");
        }
    }
}