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
        public DbSet<ProductInBusket> Busket { get; set; }

        public DbSet<BonusAction> BonusHistory { get; set; }

        public GeekComicsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Построение отношений между моделями
            //https://metanit.com/sharp/entityframework/6.2.php
            //https://docs.microsoft.com/ru-ru/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
