using GeekComics.Domain.Models;
using GeekComics.Domain.Services;

namespace GeekComics.WPF.ViewModels.Factories
{
    public class OrdersViewModelFactory : IGeekComicsViewModelFactory<OrdersViewModel>
    {
        private IDataService<Order> _orderDataService;

        public OrdersViewModelFactory(IDataService<Order> orderDataService)
        {
            _orderDataService = orderDataService;
        }

        public OrdersViewModel CreateViewModel()
        {
            return new OrdersViewModel(_orderDataService);
        }
    }
}
