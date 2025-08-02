using System;
using eCommerce.Models;
using eCommerce.Models.SearchObjects;

namespace eCommerce.Services.Interfaces;

public interface IService<TModel, TSearch> where TSearch : BaseSearchObject
{
    public PagedResult<TModel> GetPaged(TSearch search);
    public TModel? GetById(int id);
}
