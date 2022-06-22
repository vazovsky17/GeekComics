using System;
using System.Windows.Input;
using GeekComics.Domain.Models;
using GeekComics.EntityFramework;
using GeekComics.EntityFramework.Services;
using GeekComics.WPF.State.Navigators;
using GeekComics.WPF.ViewModels;

namespace GeekComics.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType) parameter;
                switch (viewType)
                {
                    case ViewType.CATALOG:
                        _navigator.CurrentViewModel = CatalogViewModel.LoadViewModel(new GenericDataService<Product>(new GeekComicsDbContextFactory()));
                        break;
                    case ViewType.PROFILE:
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                    case ViewType.BONUSES:
                        _navigator.CurrentViewModel = new BonusesViewModel();
                        break;
                    case ViewType.ORDERS:
                        _navigator.CurrentViewModel = OrdersViewModel.LoadViewModel(new GenericDataService<Order>(new GeekComicsDbContextFactory()));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
