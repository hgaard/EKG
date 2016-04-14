using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotDeadYet;

namespace EKG.TestApp
{
    public class HealthCheck : IHealthCheck
    {
        public string Description => "Will check if all is ok";

        public void Check()
        {
            if (DateTimeOffset.Now.Second % 2 != 0) throw new HealthCheckFailedException("Odd seconds are evil.");
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}