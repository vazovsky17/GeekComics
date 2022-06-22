using System;
using System.Collections.Generic;
using GeekComics.Domain.Models;
using GeekComics.EntityFramework.Services;

namespace GeekComics.WPF.ViewModels
{
    public class BonusesViewModel : ViewModelBase
    {
        private readonly GenericDataService<BonusAction> _dataService;
        public IEnumerable<BonusAction> BonusHistory;

        public BonusesViewModel(GenericDataService<BonusAction> dataService)
        {
            _dataService = dataService;
        }

        public static BonusesViewModel LoadViewModel(GenericDataService<BonusAction> dataService)
        {
            BonusesViewModel bonusesViewModel = new BonusesViewModel(dataService);
            bonusesViewModel.LoadBonusHistory();
            return bonusesViewModel;
        }

        private void LoadBonusHistory()
        {
            _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    BonusHistory = task.Result;
                }
            });
        }
    }
}
