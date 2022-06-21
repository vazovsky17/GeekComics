using System;
using System.Windows.Input;
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
                        _navigator.CurrentViewModel = new CatalogViewModel();
                        break;
                    case ViewType.PROFILE:
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                    case ViewType.BONUSES:
                        _navigator.CurrentViewModel = new BonusesViewModel();
                        break;
                    case ViewType.ORDERS:
                        _navigator.CurrentViewModel = new OrdersViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
