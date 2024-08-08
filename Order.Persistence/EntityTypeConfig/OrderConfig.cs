using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain;


namespace Orders.Persistence.EntityTypeConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order  => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();           
        }
    }
}
