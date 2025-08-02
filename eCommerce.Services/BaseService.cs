using System;
using eCommerce.Models;
using eCommerce.Models.SearchObjects;
using eCommerce.Services.Interfaces;
using MapsterMapper;

namespace eCommerce.Services;

public class BaseService<TModel, TSearch, TDbEntity>(
    AppDbContext dbContext,
    IMapper mapper
    ) : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
{
    public AppDbContext _dbContext = dbContext;
    public IMapper _mapper = mapper;

    public TModel? GetById(int id)
    {
        var entity = _dbContext.Set<TDbEntity>().Find(id);

        if (entity == null)
        {
            return null;
        }

        return _mapper.Map<TDbEntity, TModel>(entity);
    }

    public PagedResult<TModel> GetPaged(TSearch search)
    {
        List<TModel> result = [];

        var query = _dbContext.Set<TDbEntity>().AsQueryable();

        query = AddFilter(search, query);

        int count = query.Count();

        if (search.Page.HasValue && search.PageSize.HasValue)
        {
            query = query.Skip(search.Page.Value).Take(search.PageSize.Value * search.Page.Value);
        }

        var list = query.ToList();

        result = _mapper.Map(list, result);

        var response = new PagedResult<TModel>
        {
            ResultList = result,
            Count = count
        };

        return response;
    }

    public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query)
    {
        return query;
    }
}
