using Endpoints.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Endpoints.Data
{
    public class EndpointRepository: IEndpointRepository
    {
        private readonly EndpointsContext _context;

        public EndpointRepository(EndpointsContext context)
        {
            _context = context;
        }

        public List<Endpoint> GetAll()
        {
            return _context.Endpoints.ToList();
        }

        public void Insert(Endpoint endpoint)
        {
            _context.Endpoints.Add(endpoint);
        }

        public void Delete(Endpoint endpoint)
        {
            _context.Endpoints.Remove(endpoint);
        }
    }
}
