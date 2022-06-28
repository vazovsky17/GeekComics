using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services;

namespace GeekComics.WPF.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly IDataService<Product> _dataService;

        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public CatalogViewModel(IDataService<Product> dataService)
        {
            _dataService = dataService;
            LoadProducts();
        }

        public async void LoadProducts()
        {
            await _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _products = task.Result;
                }
                MessageBox.Show(_products.FirstOrDefault().Name);
            });
        }
    }
}
