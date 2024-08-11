using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Application.Orders.Queries.GetOrderList;
using Xunit;

namespace Orders.Tests.Orders.Queries
{
    public class GetOrderListQueryHandlerTests
    {
        [Fact]
        public void GetNoteListQueryHandler_Success()
        {
            var handler = new GetOrderListQueryHandler();
        }
    }
}
