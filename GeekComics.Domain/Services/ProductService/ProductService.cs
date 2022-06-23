using System.Runtime.CompilerServices;
using GeekComics.Domain.Models;

namespace GeekComics.Domain.Services.ProductService
{
    public class ProductService : IProductService
    {
        // TODO: Сделать с исключениями и бОльшей проверкой

        private readonly IDataService<Product> _productService;

        public ProductService(IDataService<Product> productService)
        {
            _productService = productService;
        }

        public async Task<Product> AddProductToCatalog(Product product)
        {
            Product createdProduct = await _productService.Create(product);
            return createdProduct;
        }

        public async Task<Product> UpdateProductInCatalog(int productId, Product product)
        {
            Product updatedProduct = await _productService.Update(productId, product);
            return updatedProduct;
        }

        public async Task<bool> DeleteProductFromCatalog(int productId)
        {
            bool isDeleted = await _productService.Delete(productId);
            return isDeleted;
        }
    }
}
