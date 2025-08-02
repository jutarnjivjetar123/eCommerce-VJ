using System;

namespace eCommerce.Models;

public class RolesResponse
{
    public int RoleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = null;
}
