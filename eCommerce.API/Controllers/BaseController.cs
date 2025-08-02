using eCommerce.Models;
using eCommerce.Models.SearchObjects;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TSearch>(IService<TModel, TSearch> service) : ControllerBase where TSearch : BaseSearchObject
    {
        protected IService<TModel, TSearch> _service = service;

        [HttpGet]
        public PagedResult<TModel> GetList([FromQuery] TSearch searchObject)
        {
            return _service.GetPaged(searchObject);
        }

        [HttpGet("{id}")]
        public TModel? GetById([FromRoute] int id)
        {
            return _service.GetById(id);
        }
    }
}
