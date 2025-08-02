using eCommerce.Models;
using eCommerce.Models.Requests;
using eCommerce.Models.SearchObjects;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService service) : BaseController<UserResponse, UsersSearchObject>(service)
    {



        [HttpPost]
        public UserResponse Insert(UsersInsertRequest request)
        {
            return service.Insert(request);
        }

        [HttpPut("{id}")]
        public UserResponse Update([FromRoute] int id, [FromBody] UsersUpdateRequest request)
        {
            return service.Update(id, request);
        }
    }
}
