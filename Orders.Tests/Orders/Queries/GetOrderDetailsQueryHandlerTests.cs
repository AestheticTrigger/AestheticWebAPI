using AutoMapper;
using Orders.Application.Orders.Queries.GetOrderDetails;
using Orders.Persistence;
using Orders.Tests.Common;
using Shouldly;
using Xunit;

namespace Orders.Tests.Orders.Queries
{
    [Collection("QueryCollection")]
    public class GetOrderDetailsQueryHandlerTests
    {
        private readonly OrdersDbContext Context;
        private readonly IMapper Mapper;

        public GetOrderDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetOrderDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetOrderDetailsQueryHandler(Context, Mapper);

            // Act 
            var result = await handler.Handle(
                new GetOrderDetailsQuery
                {
                    UserId = OrdersContextFactory.UserBId,
                    Id = Guid.Parse("79B95B19-EE51-441B-AFFB-1CD4AAA154FA")
                },
                CancellationToken.None);

            result.ShouldBeOfType<OrderDetailsVm>();
            result.OrderStatus.ShouldBe("Test2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
