using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Serilog;

namespace EKG
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.LetThereBeIoC();
            var container = IoC.Container;

            var startup = container.Resolve<Startup>();
            startup.Start();

            // The intention is that this service will expose an endpoint for registering
            ServiceRegistry.Register(new Service("Sample app", "http://localhost:62100/healthcheck"));

            var pinger = new Pinger(Log.Logger);


            pinger.Start();

        }
    }
}
