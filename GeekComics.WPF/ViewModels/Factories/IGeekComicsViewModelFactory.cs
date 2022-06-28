namespace GeekComics.WPF.ViewModels.Factories
{
    public interface IGeekComicsViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
