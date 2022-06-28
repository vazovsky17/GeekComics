using System;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels.Factories
{
    public class GeekComicsViewModelFactory : IGeekComicsViewModelFactory
    {
        private readonly CreateViewModel<CatalogViewModel> _catalogViewModelFactory;
        private readonly CreateViewModel<ProfileViewModel> _profileViewModelFactory;
        private readonly CreateViewModel<OrdersViewModel> _ordersViewModelFactory;
        private readonly CreateViewModel<BonusesViewModel> _bonusesViewModelFactory;
        private readonly CreateViewModel<LoginViewModel> _loginViewModelFactory;

        public GeekComicsViewModelFactory(CreateViewModel<CatalogViewModel> catalogViewModelFactory,
            CreateViewModel<ProfileViewModel> profileViewModelFactory,
            CreateViewModel<OrdersViewModel> ordersViewModelFactory,
            CreateViewModel<BonusesViewModel> bonusesViewModelFactory,
            CreateViewModel<LoginViewModel> loginViewModelFactory)
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
                case ViewType.CATALOG: return _catalogViewModelFactory();
                case ViewType.PROFILE: return _profileViewModelFactory();
                case ViewType.ORDERS: return _ordersViewModelFactory();
                case ViewType.BONUSES: return _bonusesViewModelFactory();
                case ViewType.LOGIN: return _loginViewModelFactory();

                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
