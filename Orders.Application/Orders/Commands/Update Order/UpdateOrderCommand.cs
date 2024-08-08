using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Orders.Application.Orders.Commands.Update_Order
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string OrderStatus { get; set; }
        
    }
}
