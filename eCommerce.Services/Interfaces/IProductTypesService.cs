using System;
using System.Linq.Dynamic.Core;
using eCommerce.Models;
using eCommerce.Models.SearchObjects;

namespace eCommerce.Services.Interfaces;

public interface IProductTypesService : IService<ProductTypesResponse, ProductTypesSearchObject>
{
}
