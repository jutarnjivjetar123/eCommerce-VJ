using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("SalesInvoiceItems")]
public class SalesInvoiceItem
{
    [Key]
    public int SalesInvoiceItemId { get; set; }

    public int SalesInvoiceId { get; set; }

    [ForeignKey(nameof(SalesInvoiceId))]
    public SalesInvoice? SalesInvoice { get; set; } = null;

    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; } = null;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; } = 0.0m;

    [Column(TypeName = "decimal(5,2)")]
    [Range(0, double.MaxValue)]
    public decimal? Discount { get; set; } = null;


}
