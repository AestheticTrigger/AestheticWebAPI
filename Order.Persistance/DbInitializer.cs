namespace Orders.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(OrdersDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
