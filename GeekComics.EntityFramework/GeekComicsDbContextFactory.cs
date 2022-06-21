using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeekComics.EntityFramework
{
    public class GeekComicsDbContextFactory : IDesignTimeDbContextFactory<GeekComicsDbContext>
    {
        public GeekComicsDbContext CreateDbContext(string[] args = null)
        {
            string sqlServerString = "Server=(localdb)\\MSSQLLocalDB;Database=GeekComics;Trusted_Connection=True";
            var options = new DbContextOptionsBuilder<GeekComicsDbContext>();
            options.UseSqlServer(sqlServerString);
            return new GeekComicsDbContext(options.Options);
        }
    }
}
