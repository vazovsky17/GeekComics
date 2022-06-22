using System.Runtime.CompilerServices;
using System.Windows.Input;
using GeekComics.WPF.Commands;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
        private readonly ICommand _updateCurrentViewModelCommand;

        public MainViewModel()
        {
            // TODO: Сделать нормальную простановку первой вьюмодели 
            _updateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(Navigator);
            _updateCurrentViewModelCommand.Execute(ViewType.CATALOG);
        }
    }
}
