using Endpoints.Business.Entity;
using System.Collections.Generic;

namespace Endpoints.Business.Services
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
