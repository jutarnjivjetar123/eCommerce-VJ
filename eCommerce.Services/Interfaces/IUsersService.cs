using System;
using eCommerce.Models;
using eCommerce.Models.Requests;
using eCommerce.Models.SearchObjects;

namespace eCommerce.Services.Interfaces;

public interface IUsersService : IService<UserResponse, UsersSearchObject>
{
    UserResponse Insert(UsersInsertRequest request);
    UserResponse Update(int id, UsersUpdateRequest request);
}
