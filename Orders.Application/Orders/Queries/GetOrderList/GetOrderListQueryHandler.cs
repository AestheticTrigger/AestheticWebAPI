using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Application.Interfaces;

namespace Orders.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = await _dbContext.Orders
                .Where(order => order.UserId == request.UserId)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new OrderListVm { Orders = ordersQuery };
        }

    }
}
