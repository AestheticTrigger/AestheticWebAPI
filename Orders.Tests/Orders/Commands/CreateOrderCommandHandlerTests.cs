using Orders.Tests.Common;
using Orders.Application.Orders.Commands.Create_Order;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Orders.Tests.Orders.Commands
{
    public class CreateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateOrderCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateOrderCommandHandler(Context);
            var orderFirstname = "order Firstname";
            var orderLastname = "order Lastname";
            var orderDetails = "order details";
            var orderPhoneNumber = 3800000000000;

            //Act
            var orderId = await handler.Handle(new CreateOrderCommand
            {
                FirstName = orderFirstname,
                LastName = orderLastname,
                Details = orderDetails,
                PhoneNumber = orderPhoneNumber
            },
            CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Orders.SingleOrDefaultAsync(order =>
            order.Id == orderId && order.FirstName == orderFirstname && order.LastName == orderLastname &&
            order.Details == orderDetails && order.PhoneNumber == orderPhoneNumber));
        }

    }
}