﻿using System;
using System.Windows;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services;
using GeekComics.Domain.Services.BusketService;
using GeekComics.Domain.Services.OrderServices;
using GeekComics.Domain.Services.OrdersService;
using GeekComics.Domain.Services.ProductService;
using GeekComics.EntityFramework;
using GeekComics.EntityFramework.Services;
using GeekComics.WPF.State.Navigators;
using GeekComics.WPF.ViewModels;
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
            Window window = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>()
            };

            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<GeekComicsDbContextFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddSingleton<IDataService<Product>, GenericDataService<Product>>();
            services.AddSingleton<IDataService<Order>, GenericDataService<Order>>();
            services.AddSingleton<IDataService<ProductInBusket>, GenericDataService<ProductInBusket>>();

            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IBusketService, BusketService>();

            return services.BuildServiceProvider();
        }
    }
}
