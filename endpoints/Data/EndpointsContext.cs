using Endpoints.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endpoints.Data
{
    public class EndpointsContext : DbContext
    {

        public EndpointsContext()
        {

        }

        public EndpointsContext(DbContextOptions<EndpointsContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Endpoint>(eb =>
                {
                    eb.HasKey(m => m.SerialNumber);
                });
        }

        public DbSet<Endpoint> Endpoints { get; set; }
    }
}
