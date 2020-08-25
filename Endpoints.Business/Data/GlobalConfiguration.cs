using Endpoints.Business.Entity;
using System.Collections.Generic;

namespace Endpoints.Business.Data
{
    public static class GlobalConfiguration
    {
        public static List<Endpoint> Endpoints { get; set; }

        static GlobalConfiguration() => Endpoints = new List<Endpoint>();
    }
}
