using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels.Factories
{
    public interface IRootGeekComicsViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
