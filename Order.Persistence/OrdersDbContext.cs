using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;
using Orders.Domain;
using Orders.Persistence.EntityTypeConfig;

namespace Orders.Persistence
{
    public class OrdersDbContext : DbContext, IOrdersDbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfig());
            base.OnModelCreating(builder);
        }
    }
}
