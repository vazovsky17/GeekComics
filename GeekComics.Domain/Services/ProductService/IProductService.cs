using GeekComics.Domain.Models;

namespace GeekComics.Domain.Services.ProductService
{
    public interface IProductService
    {
        /// <summary>
        /// Добавление товара в каталог
        /// </summary>
        /// <param name="product">Новый товар</param>
        /// <returns>Добавленный товар</returns>
        Task<Product> AddProductToCatalog(Product product);

        /// <summary>
        /// Обновление данных о товаре в каталоге 
        /// </summary>
        /// <param name="product">Обновленная версия товара</param>
        /// <returns>Измененный товар</returns>
        Task<Product> UpdateProductInCatalog(int productId, Product product);

        /// <summary>
        /// Удаление товара из каталога
        /// </summary>
        /// <param name="productId">ID удаляемого товара</param>
        /// <returns>Удален ли товар</returns>
        Task<bool> DeleteProductFromCatalog(int productId);
    }
}
