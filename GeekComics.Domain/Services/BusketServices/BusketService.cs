using GeekComics.Domain.Models;

namespace GeekComics.Domain.Services.BusketService
{
    public class BusketService : IBusketService
    {
        private readonly IDataService<Account> _accountService;

        public async Task<AddToBusketResult> AddProductToBusket(Account account, Product product, int count)
        {
            AddToBusketResult result = AddToBusketResult.Success;

            if (product.StockAvailabilityCount + product.StoreAvailabilityCount < count)
            {
                result = AddToBusketResult.NotEnoughProduct;
            }
            else if (product.StoreAvailabilityCount < count)
            {
                result = AddToBusketResult.DeliveryTimeMayBeExtended;
            }

            if (result != AddToBusketResult.NotEnoughProduct)
            {
                ProductInBusket productInBusket = new ProductInBusket()
                {
                    Product = product,
                    Count = count,
                };
                account.Busket.Add(productInBusket);
                await _accountService.Update(account.Id, account);
            }

            return result;
        }

        public async Task<ProductInBusket> DeleteProductFromBusket(Account account, ProductInBusket product)
        {
            account.Busket.Remove(product);
            await _accountService.Update(account.Id, account);
            return product;
        }
    }
}
