using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using NotDeadYet;

namespace EKG.TestApp
{
    public class NancyBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var thisAssembly = typeof(NancyBootstrapper).Assembly;
            var notDeadYetAssembly = typeof(IHealthChecker).Assembly;

            var healthChecker = new HealthCheckerBuilder()
                .WithHealthChecksFromAssemblies(thisAssembly, notDeadYetAssembly)
                .Build();

            container.Update(builder =>
                builder.Register(x=> healthChecker));
        }
    }
}