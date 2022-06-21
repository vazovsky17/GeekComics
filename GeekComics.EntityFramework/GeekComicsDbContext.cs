using GeekComics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekComics.EntityFramework
{
    public class GeekComicsDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public GeekComicsDbContext(DbContextOptions options) : base(options) { }
    }
}
