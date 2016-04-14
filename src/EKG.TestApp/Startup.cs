using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Autofac;
using EKG.TestApp;
using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup(typeof(Startup))]

namespace EKG.TestApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureLogging();

            ConfigureIoC();

            app.UseNancy();

            Log.Information("Application started.");
        }

        private static void ConfigureLogging()
        {
            var log = new LoggerConfiguration()
                .WriteTo.Seq(ConfigurationManager.AppSettings["SeqServerUrl"])
                //.WriteTo.RethinkDb()
                .CreateLogger();
            Log.Logger = log;
        }

        private static void ConfigureIoC()
        {
            try
            {
                IoC.LetThereBeIoC();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error creating IoC container");
                throw;
            }
        }

        public static class IoC
        {
            private static IContainer _container;

            public static IContainer Container => _container;

            public static void LetThereBeIoC()
            {
                var builder = new ContainerBuilder();

                builder.RegisterAssemblyModules(typeof (IoC).Assembly);
                _container = builder.Build();
            }
        }
    }
}
