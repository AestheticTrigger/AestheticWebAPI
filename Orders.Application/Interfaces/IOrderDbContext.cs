using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Orders.Domain;


namespace Orders.Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
