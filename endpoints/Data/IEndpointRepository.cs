using Endpoints.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Data
{
    public interface IEndpointRepository
    {
        List<Endpoint> GetAll();
        void Insert(Endpoint endpoint);
    }
}
