using System;
using System.Windows.Input;
using GeekComics.WPF.State.Navigators;
using GeekComics.WPF.ViewModels.Factories;

namespace GeekComics.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IGeekComicsViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IGeekComicsViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType) parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
