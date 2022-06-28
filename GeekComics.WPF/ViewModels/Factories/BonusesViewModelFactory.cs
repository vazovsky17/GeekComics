using GeekComics.Domain.Models;
using GeekComics.Domain.Services;

namespace GeekComics.WPF.ViewModels.Factories
{
    public class BonusesViewModelFactory : IGeekComicsViewModelFactory<BonusesViewModel>
    {
        private IDataService<BonusAction> _bonusesDataService;

        public BonusesViewModelFactory(IDataService<BonusAction> bonusesDataService)
        {
            _bonusesDataService = bonusesDataService;
        }

        public BonusesViewModel CreateViewModel()
        {
            return new BonusesViewModel(_bonusesDataService);
        }
    }
}
