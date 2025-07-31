using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;
using Microsoft.Identity.Client;

namespace eCommerce.Models.Entities;

[Table("Warehouses")]
public class Warehouse
{
    [Key]
    public int WarehouseId { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(150)]
    public string? Address { get; set; } = null;

    [MaxLength(500)]
    public string? Description { get; set; } = null;

    public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();

    public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
}
