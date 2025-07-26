using System;
using eCommerce.Models.Entities;

namespace eCommerce.Services.Interfaces;

public interface IProductService
{
    List<Product> GetList();
}
