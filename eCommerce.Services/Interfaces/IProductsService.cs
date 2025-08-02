using System;
using eCommerce.Models;
using eCommerce.Models.Entities;
using eCommerce.Models.SearchObjects;

namespace eCommerce.Services.Interfaces;

public interface IProductsService : IService<ProductResponse, ProductsSearchObject>
{
    
}
