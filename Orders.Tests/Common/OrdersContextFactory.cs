using Microsoft.EntityFrameworkCore;
using Orders.Domain;
using Orders.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Common
{
    public class OrdersContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        
        public static Guid OrderIdForUpdate = Guid.NewGuid();

        public static OrdersDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new OrdersDbContext(options);
            context.Database.EnsureCreated();
            context.Orders.AddRange(
                new Order
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    UpdateStatus = null,
                    Id = Guid.Parse("35C90DD9-2D82-45BB-A66F-72C5DB80F286"),
                    FirstName = "Name1",
                    LastName = "Name2",
                    UserId = UserAId, 
                    PhoneNumber = 380635519940,
                    OrderStatus = "Test1"
                },

                new Order
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    UpdateStatus = null,
                    Id = Guid.Parse("79B95B19-EE51-441B-AFFB-1CD4AAA154FA"),
                    FirstName = "Name3",
                    LastName = "Name4",
                    UserId = UserBId,
                    PhoneNumber = 380957726003,
                    OrderStatus = "Test2"
                },

                new Order
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    UpdateStatus = null,
                    Id = OrderIdForUpdate,
                    FirstName = "Name3",
                    LastName = "Name4",
                    UserId = UserBId,
                    PhoneNumber = 380957726003,
                    OrderStatus = "Test2"
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy (OrdersDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
