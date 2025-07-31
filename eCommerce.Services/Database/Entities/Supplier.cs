using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("Suppliers")]
public class Supplier
{

    [Key]
    public int SupplierId { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ContactPerson { get; set; } = null;

    [Required, MaxLength(100)]
    public string Address { get; set; } = string.Empty;

    [Required, MaxLength(25)]
    public string PhoneNumber { get; set; } = string.Empty;

    [MaxLength(25)]
    public string? Fax { get; set; } = null;

    [MaxLength(100)]
    public string? Web { get; set; } = null;

    [Required, MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? BankAccountNumber { get; set; } = null;

    [MaxLength(500)]
    public string? Note { get; set; } = null;
    public bool Status { get; set; }
    public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();

}
