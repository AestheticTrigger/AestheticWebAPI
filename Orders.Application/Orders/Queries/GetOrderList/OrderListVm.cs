using System.Collections.Generic;

namespace Orders.Application.Orders.Queries.GetOrderList
{
    public class OrderListVm
    {
        public IList<OrderLookupDto> Orders { get; set; }
    }
}
