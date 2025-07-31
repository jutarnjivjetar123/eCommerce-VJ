using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;
using Microsoft.Identity.Client;

namespace eCommerce.Models.Entities;

[Table("Users")]
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required, MaxLength(100)]
    public string? Email { get; set; } = null;

    [MaxLength(20)]
    public string? PhoneNumber { get; set; } = null;

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string PasswordHash { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string PasswordSalt { get; set; } = string.Empty;

    [Required]
    public bool? Status { get; set; } = true;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();


    public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
}
