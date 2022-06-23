using System;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels.Factories
{
    public class GeekComicsViewModelFactory : IGeekComicsViewModelFactory
    {
        private readonly CreateViewModel<CatalogViewModel> _createCatalogViewModel;
        private readonly CreateViewModel<BonusesViewModel> _createBonusesViewModel;
        private readonly CreateViewModel<OrdersViewModel> _createOrdersViewModel;
        private readonly CreateViewModel<ProfileViewModel> _createProfileViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public GeekComicsViewModelFactory(CreateViewModel<CatalogViewModel> createCatalogViewModel, CreateViewModel<BonusesViewModel> createBonusesViewModel, CreateViewModel<OrdersViewModel> createOrdersViewModel, CreateViewModel<ProductViewModel> createProductViewModel, CreateViewModel<ProfileViewModel> createProfileViewModel, CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createCatalogViewModel = createCatalogViewModel;
            _createBonusesViewModel = createBonusesViewModel;
            _createOrdersViewModel = createOrdersViewModel;
            _createProfileViewModel = createProfileViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.CATALOG:
                    return _createCatalogViewModel();
                case ViewType.BONUSES:
                    return _createBonusesViewModel();
                case ViewType.ORDERS:
                    return _createOrdersViewModel();
                case ViewType.PROFILE:
                    return _createProfileViewModel();
                case ViewType.LOGIN:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
