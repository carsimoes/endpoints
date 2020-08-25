using AutoFixture;
using Endpoints.Data;
using Endpoints.Entity;
using Endpoints.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
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
            var mockService = new Mock<IEndpointService>();
            
            var listed = mockService.Setup(x => x.ListAll()).Returns(new List<Endpoint>() { 
                new Endpoint(){ SerialNumber = "888"}
            });

            var resultList = mockService.Object.ListAll();

            Assert.Equal(1, resultList.Count);
        }

    }
}
