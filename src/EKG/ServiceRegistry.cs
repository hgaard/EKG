using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKG
{
    public static class ServiceRegistry
    {
        private static readonly List<Service> _services = new List<Service>(); 
        public static IEnumerable<Service>  Services => _services;

        public static void Register(Service service)
        {
            _services.Add(service);
        }
    }

    public class Service
    {
        public Service(string name, string url)
        {
            Name = name;
            Url = url;
        }
        public string Name { get; }
        public string Url { get;  }
    }
}
