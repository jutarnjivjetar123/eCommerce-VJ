using System;
using System.Runtime.InteropServices;
using eCommerce.Models;
using eCommerce.Models.Entities;
using eCommerce.Models.SearchObjects;
using eCommerce.Services.Interfaces;
using MapsterMapper;

namespace eCommerce.Services;

public class ProductsService(AppDbContext dbContext, IMapper mapper) : BaseService<ProductResponse, ProductsSearchObject, Product>(dbContext, mapper), IProductsService
{
    public override IQueryable<Product> AddFilter(ProductsSearchObject search, IQueryable<Product> query)
    {
        var filteredQuery = base.AddFilter(search, query);

        if (!string.IsNullOrEmpty(search.FTS))
        {
            filteredQuery = filteredQuery.Where(x => x.Name.Contains(search.FTS));
        }

        return filteredQuery;
    }
}
