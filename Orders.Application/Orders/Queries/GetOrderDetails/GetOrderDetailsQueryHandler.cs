using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MediatR;
using Orders.Domain;
using Orders.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Common.Exceptions;

namespace Orders.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IOrderDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderDetailsVm>(entity);
        }
    }
}
