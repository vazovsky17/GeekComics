using System.Security.Principal;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services.BusketService;
using GeekComics.Domain.Services.OrdersService;

namespace GeekComics.Domain.Services.OrderServices
{
    // TODO: Сделать с исключениями

    public class OrderService : IOrderService
    {
        private readonly IDataService<Account> _accountService;
        private readonly IDataService<Order> _ordersService;
        private readonly IDataService<BonusAction> _bonusesService;
        private readonly IDataService<Product> _productService;

        public OrderService(IDataService<Account> accountService, IDataService<Order> ordersService, IDataService<BonusAction> bonusesService, IDataService<Product> productService)
        {
            _accountService = accountService;
            _ordersService = ordersService;
            _bonusesService = bonusesService;
            _productService = productService;
        }

        public async Task<CreateOrderResult> CreateOrder(Account buyer, IEnumerable<ProductInBusket> products, bool isWastedBonuses)
        {
            CreateOrderResult result = CreateOrderResult.Success;

            int dayDelivired = 3;

            foreach (var product in products)
            {
                if (product.Product.StockAvailabilityCount + product.Product.StoreAvailabilityCount < product.Count)
                {
                    result = CreateOrderResult.NotEnoughProduct;
                }
                else if (product.Product.StoreAvailabilityCount < product.Count)
                {
                    // Если есть товар со склада, то дата доставки увеличивается на 2 дня
                    dayDelivired = 5;
                }
            }

            double price = products.Sum((p) => p.Product.Price * p.Count);

            double bonusAccrual = isWastedBonuses ? 0 : price * 0.1;
            double bonusWasted = !isWastedBonuses ? 0 : buyer.BonusCount;

            price += bonusWasted;
            if (price > buyer.Balance)
            {
                result = CreateOrderResult.InsufficientBalance;
            }

            DateTime dateCreated = DateTime.Now;
            DateTime dateDelivered = dateCreated.AddDays(dayDelivired);

            if (result == CreateOrderResult.Success)
            {
                foreach (var product in products)
                {
                    DecreaseProductAvailability(product.Product, product.Count);
                }

                BonusAction action = new BonusAction()
                {
                    BonusCount = bonusAccrual == 0 ? bonusWasted : bonusAccrual,
                    IsAccrual = bonusAccrual != 0,
                };
                buyer.BonusHistory.Add(action);

                // await _bonusesService.Create(action);

                buyer.BonusCount += bonusAccrual;
                buyer.BonusCount -= bonusWasted;

                Order order = new Order()
                {
                    Buyer = buyer,
                    Products = products,
                    Price = price,
                    BonusAction = action,
                    DateCreated = dateCreated,
                    DateDelivered = dateDelivered,
                    IsCancelled = false
                };
                // await _ordersService.Create(order);

                buyer.Balance -= price;
                buyer.Orders.Add(order);
                buyer.Busket.Clear();
                await _accountService.Update(buyer.Id, buyer);
            }

            return result;

        }

        private async void DecreaseProductAvailability(Product product, int count)
        {
            var stock = product.StoreAvailabilityCount;
            var store = product.StoreAvailabilityCount;
            if (store > count)
            {
                store -= count;
            }
            else
            {
                stock -= (count - store);
                store = 0;
            }
            product.StoreAvailabilityCount = store;
            product.StockAvailabilityCount = stock;
            await _productService.Update(product.Id, product);
        }

        public async Task<Order> CancelOrder(Account buyer, Order order)
        {
            order.IsCancelled = true;
            await _ordersService.Update(order.Id, order);

            foreach (var product in order.Products)
            {
                IncreaseProductAvailability(product.Product, product.Count);
            }
            buyer.Balance += order.Price;

            BonusAction action = new BonusAction()
            {
                BonusCount = order.BonusAction.BonusCount,
                IsAccrual = !order.BonusAction.IsAccrual
            };
            // await _bonusesService.Create(bonusAction);
            buyer.BonusHistory.Add(action);

            if (action.IsAccrual)
            {
                buyer.BonusCount += action.BonusCount;
            }
            else
            {
                buyer.BonusCount -= action.BonusCount;
            }
            await _accountService.Update(buyer.Id, buyer);

            return order;
        }

        private async void IncreaseProductAvailability(Product product, int count)
        {
            // Отмененные заказы возвращаются на склад
            product.StockAvailabilityCount += count;
            await _productService.Update(product.Id, product);
        }
    }
}
