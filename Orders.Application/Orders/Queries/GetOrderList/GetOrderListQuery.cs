using System;
using MediatR;

namespace Orders.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public Guid UserId { get; set; }
    }
}
