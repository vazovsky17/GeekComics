using System.Collections.Generic;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services;

namespace GeekComics.WPF.ViewModels
{
    public class BonusesViewModel : ViewModelBase
    {
        private readonly IDataService<BonusAction> _dataService;
        public IEnumerable<BonusAction> BonusHistory;

        public BonusesViewModel(IDataService<BonusAction> dataService)
        {
            _dataService = dataService;
        }
    }
}
