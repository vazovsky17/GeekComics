using GeekComics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekComics.EntityFramework
{
    public class GeekComicsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<BonusAction> BonusHistory { get; set; }

        public GeekComicsDbContext(DbContextOptions options) : base(options) { }
    }
}
