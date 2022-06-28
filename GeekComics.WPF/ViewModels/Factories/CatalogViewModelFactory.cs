using GeekComics.Domain.Models;
using GeekComics.Domain.Services;

namespace GeekComics.WPF.ViewModels.Factories
{
    public class CatalogViewModelFactory : IGeekComicsViewModelFactory<CatalogViewModel>
    {
        private IDataService<Product> _productDataService;

        public CatalogViewModelFactory(IDataService<Product> productDataService)
        {
            _productDataService = productDataService;
        }

        public CatalogViewModel CreateViewModel()
        {
            return new CatalogViewModel(_productDataService);
        }
    }
}
