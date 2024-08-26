using Microsoft.EntityFrameworkCore;
using SYACTest.Entitys;

namespace SYACTest.AppDbContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClientsEntity> clients { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PurchesOrders> purchesOrders { get; set; }

        public DbSet<OrderProducts> orderProducts { get; set; }

    }
}
