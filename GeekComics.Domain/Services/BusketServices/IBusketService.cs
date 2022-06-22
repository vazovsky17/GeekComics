using GeekComics.Domain.Models;

namespace GeekComics.Domain.Services.BusketService
{
    public enum AddToBusketResult
    {
        Success,
        NotEnoughProduct,
        DeliveryTimeMayBeExtended
    }

    public interface IBusketService
    {
        //TODO Сделать увеличение количества товара на 1 и уменьшение на 1, но это не точно

        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="account">Аккаунт</param>
        /// <param name="product">Добавляемый товар</param>
        /// <param name="count">Количество товара</param>
        /// <returns></returns>
        Task<AddToBusketResult> AddProductToBusket(Account account, Product product, int count);

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="account">Аккаунт</param>
        /// <param name="product">Товар</param>
        /// <returns></returns>
        Task<ProductInBusket> DeleteProductFromBusket(Account account, ProductInBusket product);
    }
}
