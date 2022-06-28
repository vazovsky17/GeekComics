

using System;
using System.Linq;
using System.Windows;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services;
using GeekComics.Domain.Services.AuthentificationServices;
using GeekComics.Domain.Services.BusketService;
using GeekComics.Domain.Services.OrderServices;
using GeekComics.Domain.Services.OrdersService;
using GeekComics.Domain.Services.ProductService;
using GeekComics.EntityFramework;
using GeekComics.EntityFramework.Services;
using GeekComics.WPF.State.Accs;
using GeekComics.WPF.State.Authentificators;
using GeekComics.WPF.State.Navigators;
using GeekComics.WPF.ViewModels;
using GeekComics.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace GeekComics.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<GeekComicsDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IBusketService, BusketService>();

            services.AddSingleton<IDataService<Product>, GenericDataService<Product>>();
            services.AddSingleton<IDataService<Order>, GenericDataService<Order>>();
            services.AddSingleton<IDataService<BonusAction>, GenericDataService<BonusAction>>();
            services.AddSingleton<IDataService<ProductInBusket>, GenericDataService<ProductInBusket>>();


            services.AddSingleton<IGeekComicsViewModelFactory, GeekComicsViewModelFactory>();

            services.AddSingleton<ViewModelDelegateRenavigator<CatalogViewModel>>();
            services.AddSingleton<CatalogViewModel>();
            services.AddSingleton<CreateViewModel<CatalogViewModel>>(services =>
            {
                return () => services.GetRequiredService<CatalogViewModel>();
            });

            services.AddSingleton<ProfileViewModel>();
            services.AddSingleton<CreateViewModel<ProfileViewModel>>(services =>
            {
                return () => services.GetRequiredService<ProfileViewModel>();
            });

            services.AddSingleton<OrdersViewModel>();
            services.AddSingleton<CreateViewModel<OrdersViewModel>>(services =>
            {
                return () => services.GetRequiredService<OrdersViewModel>();
            });

            services.AddSingleton<BonusesViewModel>();
            services.AddSingleton<CreateViewModel<BonusesViewModel>>(services =>
            {
                return () => services.GetRequiredService<BonusesViewModel>();
            });

            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<CatalogViewModel>>());
            });

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
