using AutoFixture;
using Endpoints.Data;
using Endpoints.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace Endpoints.Tests
{
    public class EndpointsTest
    {
        [Fact]
        public void GetAllTest()
        {
            var testResult = new List<Endpoint>();

            var options = new DbContextOptionsBuilder<EndpointsContext>()
                  .UseInMemoryDatabase(databaseName: "EndpointsDb")
                  .Options;

            using (var context = new EndpointsContext(options))
            {
                context.Endpoints.Add(new Endpoint { SerialNumber = "1" });

                context.SaveChanges();
            }

            using (var context = new EndpointsContext(options))
            {
                EndpointRepository repository = new EndpointRepository(context);
                testResult = (List<Endpoint>)repository.GetAll();
            }

            Assert.Equal(1, testResult.Count);
        }

        [Fact]
        public void InsertTest()
        {
            var testResult = new List<Endpoint>();

            var options = new DbContextOptionsBuilder<EndpointsContext>()
              .UseInMemoryDatabase(databaseName: "EndpointsDb")
              .Options;

            using (var context = new EndpointsContext(options))
            {
                context.Endpoints.Add(new Endpoint { SerialNumber = "1" });

                context.SaveChanges();
            }

            using (var context = new EndpointsContext(options))
            {
                EndpointRepository repository = new EndpointRepository(context);
                testResult = (List<Endpoint>)repository.GetAll();
            }

            Assert.Equal(1, testResult.Count);
        }

        [Fact]
        public void DeleteTest()
        {
            var testResult = new List<Endpoint>();
            var entity = new Endpoint { SerialNumber = "1" };

            var options = new DbContextOptionsBuilder<EndpointsContext>()
              .UseInMemoryDatabase(databaseName: "EndpointsDb")
              .Options;

            using (var context = new EndpointsContext(options))
            {
                context.Endpoints.Add(entity);

                context.SaveChanges();
            }

            using (var context = new EndpointsContext(options))
            {
                var repository = new EndpointRepository(context);

                repository.Delete(entity);
                testResult = (List<Endpoint>)repository.GetAll();
            }

            Assert.Equal(1, testResult.Count);
        }
    }
}
