using System;
using System.Windows;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services;
using GeekComics.Domain.Services.ProductService;
using GeekComics.EntityFramework;
using GeekComics.EntityFramework.Services;
using GeekComics.WPF.ViewModels;

namespace GeekComics.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            GeekComicsDbContextFactory contextFactory = new EntityFramework.GeekComicsDbContextFactory();
            IAccountService accountService = new AccountDataService(contextFactory);
            IDataService<Product> productDataService = new GenericDataService<Product>(contextFactory);
            IProductService productService = new ProductService(productDataService);
            await accountService.Create(new Account
            {
                AccountHolder = new User
                {
                    Username = "Mark",
                    PasswordHash = "lol",
                    Role = Role.ADMINISTRATOR,
                },
                Balance = 500,
                BonusCount = 500,
                AddressDelivery = "Первомайская"
            });

            await productService.AddProductToCatalog(
                new Product
                {
                    Name = "Сумерки",
                    Description = "Сага",
                    Price = 100
                });


            Window window = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            window.Show();
            base.OnStartup(e);
        }
    }
}
