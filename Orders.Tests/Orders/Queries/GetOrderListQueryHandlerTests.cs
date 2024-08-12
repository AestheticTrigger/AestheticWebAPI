using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Orders.Tests.Common;
using Orders.Application.Orders.Queries.GetOrderList;
using Orders.Persistence;
using Shouldly;
using Xunit;

namespace Orders.Tests.Orders.Queries
{
    [Collection("QueryCollection")]
    public class GetOrderListQueryHandlerTests
    {
        private readonly OrdersDbContext Context;
        private readonly IMapper Mapper;

        public GetOrderListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetOrderListQueryHandler(Context, Mapper);

            // Act 
            var result = await handler.Handle(
                new GetOrderListQuery
                {
                    UserId = OrdersContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<OrderListVm>();
            result.Orders.Count.ShouldBe(2);
        }
    }
}
