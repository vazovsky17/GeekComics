using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using GeekComics.Domain.Models;
using GeekComics.EntityFramework.Services;

namespace GeekComics.WPF.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly GenericDataService<Product> _dataService;
        private ProductViewModel _productViewModel;
        public ProductViewModel ProductViewModel
        {
            get
            {
                return _productViewModel;
            }
            set
            {
                _productViewModel = value;
                OnPropertyChanged(nameof(ProductViewModel));
            }
        }

        public IEnumerable<ProductViewModel> Products;
        private IEnumerable<Product> _products;

        public CatalogViewModel(GenericDataService<Product> dataService)
        {
            _dataService = dataService;
        }

        public static CatalogViewModel LoadViewModel(GenericDataService<Product> dataService)
        {
            CatalogViewModel catalogViewModel = new(dataService);
            catalogViewModel.LoadProducts();
            return catalogViewModel;
        }

        private void LoadProducts()
        {
            _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    // TODO: Сделать отображение всех товаров ИЛИ ХОТЯ БЫ ОДНОГО, ЧЕРТ ВОЗЬМИ
                    _products = task.Result;
                    foreach (var item in _products)
                    {

                    }
                    ProductViewModel = new ProductViewModel(_products.FirstOrDefault());
                    //MessageBox.Show(_products.FirstOrDefault().Name.ToString());
                }
                else
                {
                    MessageBox.Show("Что-то не так");
                }
            });

        }
    }
}
