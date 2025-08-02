using System;
using eCommerce.Models;
using eCommerce.Models.Entities;
using eCommerce.Models.SearchObjects;
using eCommerce.Services.Interfaces;
using MapsterMapper;

namespace eCommerce.Services;

public class ProductTypesService(
    AppDbContext dbContext,
    IMapper mapper
    ) : BaseService<ProductTypesResponse, ProductTypesSearchObject, ProductType>(dbContext, mapper), IProductTypesService
{
    
}
