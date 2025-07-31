using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("Products")]
public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string ProductNumber { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; } = 0.0m;

    [Required]
    public int ProductTypeId { get; set; }

    [ForeignKey(nameof(ProductTypeId))]
    public ProductType? ProductType { get; set; } = null;

    [Required]
    public int UnitOfMeasureId { get; set; }

    [ForeignKey(nameof(UnitOfMeasureId))]
    public UnitOfMeasure? UnitOfMeasure { get; set; } = null;

    public byte[]? Image { get; set; }

    public byte[]? ThumbnailImage { get; set; }

    [Required]
    public bool? Status { get; set; } = true;

    [MaxLength(50)]
    public string? StateMachine { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();

    public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItem>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
