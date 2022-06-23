using System;
using System.Windows;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services;
using GeekComics.Domain.Services.ProductService;
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
            IAccountService accountService = new AccountDataService(new EntityFramework.GeekComicsDbContextFactory());
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



            Window window = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            window.Show();
            base.OnStartup(e);
        }
    }
}
