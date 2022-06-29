using GeekComics.WPF.State.Navigators;
using GeekComics.WPF.ViewModels.Factories;
using GeekComics.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;
using GeekComics.WPF.State.Authentificators;
using GeekComics.Domain.Services;
using GeekComics.Domain.Models;

namespace GeekComics.WPF.HostBuiders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IGeekComicsViewModelFactory, GeekComicsViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<CatalogViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();

                services.AddTransient<MainViewModel>();
                services.AddTransient(CreateCatalogViewModel);

                services.AddTransient<CatalogViewModel>();
                services.AddTransient<ProfileViewModel>();
                services.AddTransient<OrdersViewModel>();
                services.AddTransient<BonusesViewModel>();

                services.AddSingleton<CreateViewModel<CatalogViewModel>>(services => () => services.GetRequiredService<CatalogViewModel>());
                services.AddSingleton<CreateViewModel<ProfileViewModel>>(services => () => services.GetRequiredService<ProfileViewModel>());
                services.AddSingleton<CreateViewModel<OrdersViewModel>>(services => () => services.GetRequiredService<OrdersViewModel>());
                services.AddSingleton<CreateViewModel<BonusesViewModel>>(services => () => services.GetRequiredService<BonusesViewModel>());

                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));
            });

            return host;
        }

        private static CatalogViewModel CreateCatalogViewModel(IServiceProvider services)
        {
            return new CatalogViewModel
                (services.GetRequiredService<IDataService<Product>>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<CatalogViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }
    }
}
