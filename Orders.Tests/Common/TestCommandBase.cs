using Orders.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly OrdersDbContext Context;

        public TestCommandBase()
        {
            Context = OrdersContextFactory.Create();
        }

        public void Dispose()
        {
            OrdersContextFactory.Destroy(Context);
        }
    }
}
