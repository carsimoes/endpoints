using Endpoints.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Data
{
    public static class GlobalConfiguration
    {
        public static List<Endpoint> Endpoints { get; set; }

        static GlobalConfiguration() => Endpoints = new List<Endpoint>();
    }
}
