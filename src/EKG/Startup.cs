using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace EKG
{
    public class Startup
    {
        public void Start()
        {
            ConfigureLogging();

            Log.Information("Hello World!");
        }

        private void ConfigureLogging()
        {
            var log = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                //.WriteTo.RethinkDb()
                .WriteTo.Seq(ConfigurationManager.AppSettings["SeqServerUrl"])
                .Enrich.WithProperty("ApplicationVersion", GetType().Assembly.GetName().Version)
                .CreateLogger();

            Log.Logger = log;
        }
    }
}
