using eCommerce.Models;
using eCommerce.Models.Requests;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService) : ControllerBase
    {

        private readonly IUsersService _usersService = usersService;
        [HttpGet]
        public List<UserResponse> GetList()
        {
            return _usersService.GetList();
        }

        [HttpPost]
        public UserResponse Insert(UserInsertRequest request)
        {
            return _usersService.Insert(request);
        }

        [HttpPut("{id}")]
        public UserResponse Update([FromRoute] int id, [FromBody] UserUpdateRequest request)
        {
            return _usersService.Update(id, request);
        }
    }
}
