using System;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task Start()
        {
            var client = new HttpClient();
            while (true)
            {
                foreach (var service in ServiceRegistry.Services)
                {
                    var result = await client.GetAsync(service.Url);
                    var payload = await result.Content.ReadAsStringAsync();
                    try
                    {

                        var message = JsonConvert.DeserializeObject<NotYetDeadResult>(payload);

                        if (message.Status == 0)
                        {

                            _logger.Information("The world is still standing - Application {@applicationName} i still running -  ping result {@message}", service.Name, message);
                        }
                        else
                        {

                            _logger.Error("The world has fallen over - Application {@applicationName} is no longer with us - ping result {@message}", service.Name, message);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Error("Exception {exceptionMessage}", e.Message);
                    }
                    
                }

               await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
