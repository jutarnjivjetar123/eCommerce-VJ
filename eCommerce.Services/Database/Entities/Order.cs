using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("Orders")]
public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required, MaxLength(20)]
    public string OrderNumber { get; set; } = string.Empty;

    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; } = null;

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    public bool Status { get; set; }
    public bool? IsCanceled { get; set; } = null;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
}
