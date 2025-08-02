using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models.Requests;

public class UsersUpdateRequest
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;


    [Phone]
    [MaxLength(20)]
    public string? PhoneNumber { get; set; } = null;


    [MaxLength(50)]
    public string? Password { get; set; }

    [MaxLength(50)]
    public string? PasswordConfirmation { get; set; }


    public bool? Status { get; set; } = true;
}
