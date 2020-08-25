using Endpoints.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Services
{
    public interface IEndpointService
    {
        Endpoint Create(Endpoint endpointEntity);
        void Edit();
        void Delete();
        List<Endpoint> ListAll();
        void Find();
    }
}
