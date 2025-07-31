using System;
using eCommerce.Models;
using eCommerce.Models.Entities;

namespace eCommerce.Services.Interfaces;

public interface IProductService
{
    List<ProductResponse> GetList();
}
