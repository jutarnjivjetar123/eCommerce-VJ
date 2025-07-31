using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("PurchaseInvoiceItems")]
public class PurchaseInvoiceItem
{
    [Key]
    public int PurchaseInvoiceItemId { get; set; }

    [Required]
    public int PurchaseInvoiceId { get; set; }

    [ForeignKey(nameof(PurchaseInvoiceId))]
    public PurchaseInvoice? PurchaseInvoice { get; set; }

    [Required]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; } = null;

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }




}
