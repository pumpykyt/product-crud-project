using CrudProject.Data.Entities;

namespace CrudProject.Domain.Interfaces;

public interface IProductService
{
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(string productId);
    Task<IEnumerable<Product>> GetProductsAsync();
}