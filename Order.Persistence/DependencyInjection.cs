using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Interfaces;

namespace Orders.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IOrdersDbContext>(provider => provider.GetService<OrdersDbContext>());

            return services;
        }
    }
}
