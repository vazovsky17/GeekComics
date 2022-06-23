using System;
using GeekComics.WPF.ViewModels;

namespace GeekComics.WPF.State.Navigators
{
    public class Navigator : INavigator
    {
        public event Action StateChanged;
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }
    }
}
