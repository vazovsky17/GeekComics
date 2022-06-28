using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels.Factories
{
    public interface IGeekComicsViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
