using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProject.Data;
using CrudProject.Data.Entities;
using CrudProject.Domain.Interfaces;
using CrudProject.Domain.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CrudProject.UnitTests.Tests;

public class ProductServiceTests
{
    private readonly DbContextOptions<DataContext> _dbContextOptions =
        new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("UnitTestsDb")
                                                  .Options;

    private IProductService _service;

    private List<Product> _products = new List<Product>
    {
        new Product {Id = Guid.NewGuid().ToString(), Name = "Product0", Price = 50},
        new Product {Id = Guid.NewGuid().ToString(), Name = "Product1", Price = 100},
        new Product {Id = Guid.NewGuid().ToString(), Name = "Product2", Price = 150}
    };
    
    private Product _testProduct = new Product
    {
        Id = Guid.NewGuid().ToString(),
        Name = "CreateProductTest",
        Price = 999
    };

    [OneTimeSetUp]
    public async Task Setup()
    {
        await SeedDb();
        _service = new ProductService(new DataContext(_dbContextOptions));
    }

    public async Task SeedDb()
    {
        using var context = new DataContext(_dbContextOptions);
        await context.Products.AddRangeAsync(_products);
        await context.SaveChangesAsync();
    }

    [Test]
    public async Task CreateProductTest()
    {
        var result = await _service.CreateProductAsync(_testProduct);
        
        Assert.IsTrue(result);
    }

    [Test]
    public async Task UpdateProductTest()
    {
        var newProduct = new Product
        {
            Id = _products.First().Id,
            Name = "UpdateProductTest",
            Price = 888
        };

        var result = await _service.UpdateProductAsync(newProduct);
        
        Assert.IsTrue(result);
    }

    [Test]
    public async Task GetProductsTest()
    {
        var result = await _service.GetProductsAsync();
        
        Assert.NotNull(result);
    }

    [Test]
    public async Task DeleteProductTest()
    {
        var result = await _service.DeleteProductAsync(_testProduct.Id);
        
        Assert.IsTrue(result);
    }
}