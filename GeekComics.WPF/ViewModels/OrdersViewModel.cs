using System;
using System.Collections;
using System.Collections.Generic;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services;

namespace GeekComics.WPF.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly IDataService<Order> _dataService;
        private IEnumerable<Order> _orders;
        public IEnumerable<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public OrdersViewModel(IDataService<Order> dataService)
        {
            _dataService = dataService;
            LoadOrders();
        }

        private async void LoadOrders()
        {
            await _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _orders = task.Result;
                }
            }); ;
        }
    }
}
