using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("SalesInvoices")]
public class SalesInvoice
{
    [Key]
    public int SalesInvoiceId { get; set; }

    [Required, MaxLength(50)]
    public string InvoiceNumber { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; } = null;

    public bool IsCompleted { get; set; } = false;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal AmountVATExcluded { get; set; } = 0.0m;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal AmountVATIncluded { get; set; } = 0.0m;

    public int? OrderId { get; set; } = null;

    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; } = null;

    [Required]
    public int WarehouseId { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    public Warehouse? Warehouse { get; set; } = null;


    public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItem>();





}
