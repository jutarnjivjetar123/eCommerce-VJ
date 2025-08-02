using eCommerce.Models;
using eCommerce.Models.SearchObjects;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController(IProductTypesService service) : BaseController<ProductTypesResponse, ProductTypesSearchObject>(service)
    {
    }
}
