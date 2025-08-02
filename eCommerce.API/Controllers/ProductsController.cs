using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Models;
using eCommerce.Models.Entities;
using eCommerce.Models.SearchObjects;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController<ProductResponse, ProductsSearchObject>
    {
        public ProductsController(IProductsService service) : base(service) { }

    }
}