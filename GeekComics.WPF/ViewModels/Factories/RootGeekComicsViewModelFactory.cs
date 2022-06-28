using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels.Factories
{
    public class RootGeekComicsViewModelFactory : IRootGeekComicsViewModelFactory
    {
        private readonly IGeekComicsViewModelFactory<CatalogViewModel> _catalogViewModelFactory;
        private readonly IGeekComicsViewModelFactory<ProfileViewModel> _profileViewModelFactory;
        private readonly IGeekComicsViewModelFactory<OrdersViewModel> _ordersViewModelFactory;
        private readonly IGeekComicsViewModelFactory<BonusesViewModel> _bonusesViewModelFactory;
        private readonly IGeekComicsViewModelFactory<LoginViewModel> _loginViewModelFactory;

        public RootGeekComicsViewModelFactory(IGeekComicsViewModelFactory<CatalogViewModel> catalogViewModelFactory, IGeekComicsViewModelFactory<ProfileViewModel> profileViewModelFactory, IGeekComicsViewModelFactory<OrdersViewModel> ordersViewModelFactory, IGeekComicsViewModelFactory<BonusesViewModel> bonusesViewModelFactory, IGeekComicsViewModelFactory<LoginViewModel> loginViewModelFactory)
        {
            _catalogViewModelFactory = catalogViewModelFactory;
            _profileViewModelFactory = profileViewModelFactory;
            _ordersViewModelFactory = ordersViewModelFactory;
            _bonusesViewModelFactory = bonusesViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.CATALOG: return _catalogViewModelFactory.CreateViewModel();
                case ViewType.PROFILE: return _profileViewModelFactory.CreateViewModel();
                case ViewType.ORDERS: return _ordersViewModelFactory.CreateViewModel();
                case ViewType.BONUSES: return _bonusesViewModelFactory.CreateViewModel();
                case ViewType.LOGIN: return _loginViewModelFactory.CreateViewModel();

                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
