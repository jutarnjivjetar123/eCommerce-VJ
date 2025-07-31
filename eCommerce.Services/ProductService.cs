using System;
using System.Runtime.InteropServices;
using eCommerce.Models;
using eCommerce.Models.Entities;
using eCommerce.Services.Interfaces;
using MapsterMapper;

namespace eCommerce.Services;

public class ProductService(AppDbContext dbContext, IMapper mapper) : IProductService
{

    private readonly AppDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;


    public List<ProductResponse> GetList()
    {
        var list = dbContext.Products.ToList();

        var result = new List<ProductResponse>();

        result = _mapper.Map(list, result);
        return result;
    }
}
