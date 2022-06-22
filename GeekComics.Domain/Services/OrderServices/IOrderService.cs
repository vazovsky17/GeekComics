using GeekComics.Domain.Models;
using GeekComics.Domain.Services.BusketService;

namespace GeekComics.Domain.Services.OrdersService
{
    public enum CreateOrderResult
    {
        Success,
        NotEnoughProduct,
        InsufficientBalance,
    }

    public interface IOrderService
    {
        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="orderHolder">Аккаунт, с которого совершается заказ</param>
        /// <param name="products">Список покупаемых товаров</param>
        /// <param name="isWastedBonuses">Будут ли тратиться бонусы</param>
        /// <returns>Созданный заказ</returns>
        Task<CreateOrderResult> CreateOrder(Account orderHolder, IEnumerable<ProductInBusket> products, bool isWastedBonuses);

        /// <summary>
        /// Отмена заказа
        /// </summary>
        /// <param name="orderHolder">Аккаунт, с которого был совершен заказ</param>
        /// <param name="order">Заказ</param>
        /// <returns>Успешная ли отмена заказа</returns>
        Task<Order> CancelOrder(Account orderHolder, Order order);
    }
}
