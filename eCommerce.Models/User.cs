using System;

namespace eCommerce.Models;

public class UserResponse
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; } = null;

    public string? PhoneNumber { get; set; } = null;

    public string Username { get; set; } = string.Empty;


    public bool? Status { get; set; } = true;

}
