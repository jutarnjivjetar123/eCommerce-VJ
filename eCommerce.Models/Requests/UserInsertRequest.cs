using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models.Requests;

public class UserInsertRequest
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    [Required, MaxLength(100)]
    public string? Email { get; set; } = null;

    [Phone]
    [MaxLength(20)]
    public string? PhoneNumber { get; set; } = null;

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Password { get; set; }

    [Required, MaxLength(50)]
    public string PasswordConfirmation { get; set; }


    public bool? Status { get; set; } = true;
}
