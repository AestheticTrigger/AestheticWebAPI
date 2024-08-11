using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Common.Exceptions;
using Orders.Application.Interfaces;
using Orders.Domain;

namespace Orders.Application.Orders.Commands.Update_Order
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrdersDbContext _dbContext;
        public UpdateOrderCommandHandler(IOrdersDbContext dbContext) => _dbContext = dbContext;               
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            entity.OrderStatus = request.OrderStatus;
            entity.UpdateStatus = DateTime.Now;
            entity.OrderStatus = request.OrderStatus;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
