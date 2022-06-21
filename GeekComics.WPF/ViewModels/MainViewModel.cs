using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainViewModel()
        {

        }
    }
}
