using System.Runtime.CompilerServices;
using System.Windows.Input;
using GeekComics.WPF.Commands;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.CATALOG);
        }
    }
}
