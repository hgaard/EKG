using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nito.AsyncEx;
using Serilog;

namespace EKG
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();

            // The intention is that this service will expose an endpoint for registering
            ServiceRegistry.Register(new Service("Sample app", "http://localhost:62100/healthcheck"));

            // Start pinging
            var pinger = new Pinger(Log.Logger);
            AsyncContext.Run(() => pinger.Start());
            pinger.Start();

        }

        private static void Init()
        {
            IoC.LetThereBeIoC();
            var container = IoC.Container;

            var startup = container.Resolve<Startup>();
            startup.Start();
        }
    }
}
