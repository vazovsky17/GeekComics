using GeekComics.Domain.Models;
using GeekComics.Domain.Services;
using GeekComics.Domain.Services.AuthentificationServices;
using GeekComics.Domain.Services.BusketService;
using GeekComics.Domain.Services.OrderServices;
using GeekComics.Domain.Services.OrdersService;
using GeekComics.Domain.Services.ProductService;
using GeekComics.EntityFramework.Services;
using GeekComics.WPF.State.Authentificators;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GeekComics.WPF.HostBuiders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IAuthenticator, Authenticator>();

                services.AddSingleton<IDataService<Account>, AccountDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();

                services.AddSingleton<IProductService, ProductService>();
                services.AddSingleton<IDataService<Product>, GenericDataService<Product>>();

                services.AddSingleton<IOrderService, OrderService>();
                services.AddSingleton<IDataService<Order>, GenericDataService<Order>>();

                services.AddSingleton<IBusketService, BusketService>();
                services.AddSingleton<IDataService<ProductInBusket>, GenericDataService<ProductInBusket>>();

                services.AddSingleton<IDataService<BonusAction>, GenericDataService<BonusAction>>();
            });

            return host;
        }
    }
}
