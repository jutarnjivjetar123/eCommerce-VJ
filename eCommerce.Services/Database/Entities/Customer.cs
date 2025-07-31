using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("Customers")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Column(TypeName = "datetime")]
    public DateTime DateOfRegistration { get; set; }

    [Required, MaxLength(100)]
    public string Email { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string PasswordHash { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string PasswordSalt { get; set; } = string.Empty;

    public bool? Status { get; set; }


    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();


    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
