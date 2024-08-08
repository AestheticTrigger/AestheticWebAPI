using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orders.Application.Interfaces;
using Orders.Domain;

namespace Orders.Application.Orders.Commands.Create_Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderDbContext _dbContext;

        public CreateOrderCommandHandler(IOrderDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken )
        {
            var order = new Order
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                FisrstName = request.FisrstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                CreationDate = DateTime.Now,
                Details = request.Details,
                OrderStatus = "InProcess"
            };

            await _dbContext.Orders.AddAsync( order, cancellationToken );
            await _dbContext.SaveChangesAsync(cancellationToken );

            return order.Id;
        }
    }
}
