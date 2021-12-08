using CrudProject.Data;
using CrudProject.Data.Entities;
using CrudProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Domain.Services;

public class ProductService : IProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        product.Id = Guid.NewGuid()
                         .ToString();
        await _context.Products.AddAsync(product);
        
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteProductAsync(string productId)
    {
        var product = await _context.Products.SingleOrDefaultAsync(t => t.Id == productId);
        _context.Products.Remove(product);
        
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.AsNoTracking()
                                      .ToListAsync();
    }
}