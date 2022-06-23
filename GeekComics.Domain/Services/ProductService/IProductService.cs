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
        Task<Product> UpdateProductInCatalog(Product product);

        /// <summary>
        /// Удаление товара из каталога
        /// </summary>
        /// <param name="product">Удаляемый товар</param>
        /// <returns>Удален ли товар</returns>
        Task<bool> DeleteProductFromCatalog(Product product);
    }
}
