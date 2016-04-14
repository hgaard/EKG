using System;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using Serilog;

namespace EKG
{
    public class Pinger
    {
        private readonly ILogger _logger;

        public Pinger(ILogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            var client = new HttpClient();
            while (true)
            {
                foreach (var service in ServiceRegistry.Services)
                {
                    var result = client.GetAsync(service.Url).Result;
                    var payload = result.Content.ReadAsStringAsync().Result;
                    try
                    {

                        var message = JsonConvert.DeserializeObject<NotYetDeadResult>(payload);

                        if (message.Status == 0)
                        {

                            _logger.Information("The world is still standing - Application {@applicationName} i still running -  ping result {@message}", service.Name, message);
                        }
                        else
                        {

                            _logger.Error("The world had fallen over - Application {@applicationName} is no longer with us - ping result {@message}", service.Name, message);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Error("Exception {exceptionMessage}", e.Message);
                        //throw;
                    }
                    
                }

               Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
    }
}
