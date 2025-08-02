using System;

namespace eCommerce.Models.SearchObjects;

public class UsersSearchObject : BaseSearchObject
{
    public string? FirstNameGTE { get; set; } = string.Empty;
    public string? LastNameGTE { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Username { get; set; } = string.Empty;
    public bool IsUserRolesIncluded { get; set; } = false;
    public string? OrderBy { get; set; } = string.Empty;

}
