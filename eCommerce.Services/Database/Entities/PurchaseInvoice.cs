using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("PurchaseInvoices")]
public class PurchaseInvoice
{
    [Key]
    public int PurchaseInvoiceId { get; set; }

    [Required, MaxLength(20)]
    public string InvoiceNumber { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal TotalAmount { get; set; } = 0.0m;

    [Column(TypeName = "numeric(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal VAT { get; set; } = 0.0m;

    [MaxLength(500)]
    public string? Notes { get; set; } = null;

    [Required]
    public int WarehouseId { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    public Warehouse? Warehouse { get; set; } = null;

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; } = null;

    [Required]
    public int SupplierId { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public Supplier? Supplier { get; set; } = null;

    public virtual ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
}
