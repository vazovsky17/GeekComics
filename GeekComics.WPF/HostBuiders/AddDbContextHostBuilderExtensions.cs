using System;
using GeekComics.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GeekComics.WPF.HostBuiders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                //string connectionString = context.Configuration.GetConnectionString("sqlite");
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=GeekComics;Trusted_Connection=True";
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);

                services.AddDbContext<GeekComicsDbContext>(configureDbContext);
                services.AddSingleton<GeekComicsDbContextFactory>(new GeekComicsDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
