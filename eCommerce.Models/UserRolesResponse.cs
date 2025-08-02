using System;

namespace eCommerce.Models;

public class UserRolesResponse
{
    public int UserRoleId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime DateOfChange { get; set; }

    public virtual RolesResponse Role { get; set; } = new RolesResponse();
}
