using System.Collections.Generic;
using GeekComics.Domain.Models;
using GeekComics.EntityFramework.Services;

namespace GeekComics.WPF.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly GenericDataService<Order> _dataService;
        public IEnumerable<Order> Orders;

        public OrdersViewModel(GenericDataService<Order> dataService)
        {
            _dataService = dataService;
        }

        public static OrdersViewModel LoadViewModel(GenericDataService<Order> dataService)
        {
            OrdersViewModel ordersViewModel = new OrdersViewModel(dataService);
            ordersViewModel.LoadOrders();
            return ordersViewModel;
        }

        private void LoadOrders()
        {
            _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Orders = task.Result;
                }
            });
        }
    }
}
