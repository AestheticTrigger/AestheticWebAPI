using AutoMapper;
using Orders.Application.Common.Mapping;
using Orders.Persistence;
using Orders.Domain;
using Orders.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public OrdersDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture() 
        {
            Context = OrdersContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IOrdersDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }
        
        public void Dispose()
        {
            OrdersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
