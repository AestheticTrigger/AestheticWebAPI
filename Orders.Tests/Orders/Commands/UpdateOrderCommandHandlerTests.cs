using Orders.Tests.Common;
using Orders.Application.Orders.Commands.Update_Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Common.Exceptions;

namespace Orders.Tests.Orders.Commands
{
    public class UpdateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateOrderCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateOrderCommandHandler(Context);
            var updatedStatus = "Forwarded to the recipient";

            // Act
            await handler.Handle(new UpdateOrderCommand
            {
                Id = OrdersContextFactory.OrderIdForUpdate,
                UserId = OrdersContextFactory.UserBId,
                OrderStatus = updatedStatus
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Orders.SingleOrDefaultAsync(order =>
                order.Id == OrdersContextFactory.OrderIdForUpdate &&
                order.OrderStatus == updatedStatus));
        }

        [Fact]
        public async Task UpdateOrderCommandHandler_FailOnWrongId()
        {
            // Arrange 
            var handler = new UpdateOrderCommandHandler(Context);

            // Act
            // Assert 
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateOrderCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = OrdersContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateOrderCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateOrderCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateOrderCommand
                    {
                        Id = OrdersContextFactory.OrderIdForUpdate,
                        UserId = OrdersContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}