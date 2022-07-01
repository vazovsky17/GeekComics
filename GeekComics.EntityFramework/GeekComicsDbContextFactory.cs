using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeekComics.EntityFramework
{
    public class GeekComicsDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public GeekComicsDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public GeekComicsDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<GeekComicsDbContext> options = new DbContextOptionsBuilder<GeekComicsDbContext>();

            _configureDbContext(options);

            return new GeekComicsDbContext(options.Options);
        }
    }
}
