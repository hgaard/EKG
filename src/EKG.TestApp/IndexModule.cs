using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace EKG.TestApp
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "Hello, world! You might be interested in the /healthcheck endpoint";
        }
    }
}