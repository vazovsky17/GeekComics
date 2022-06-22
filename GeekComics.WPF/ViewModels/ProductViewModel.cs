using GeekComics.Domain.Models;

namespace GeekComics.WPF.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private Product _product;
        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public ProductViewModel(Product product)
        {
            _product = product;
        }
    }
}
