using System;
using eCommerce.Models;
using eCommerce.Models.Requests;

namespace eCommerce.Services.Interfaces;

public interface IUsersService
{
    List<UserResponse> GetList();
    UserResponse Insert(UserInsertRequest request);
    UserResponse Update(int id, UserUpdateRequest request);
}
