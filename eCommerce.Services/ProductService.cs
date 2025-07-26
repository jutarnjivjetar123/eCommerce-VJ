using System;
using eCommerce.Models.Entities;
using eCommerce.Services.Interfaces;

namespace eCommerce.Services;

public class ProductService : IProductService
{
    public List<Product> List = new List<Product>()
    {
        new Product(){
            ProductId = 1,
            Name = "Laptop",
            Price = 999
        },
        new Product(){
            ProductId = 2,
            Name = "Monitor",
            Price = 999
        }
    };

    public List<Product> GetList()
    {
        return List;
    }
}
