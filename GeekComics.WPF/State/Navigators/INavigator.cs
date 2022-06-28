using System;
using System.Windows.Input;
using GeekComics.WPF.ViewModels;

namespace GeekComics.WPF.State.Navigators
{
    public enum ViewType
    {
        CATALOG,
        PROFILE,
        BONUSES,
        ORDERS,
        LOGIN
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
        //event Action StateChanged;
    }
}
