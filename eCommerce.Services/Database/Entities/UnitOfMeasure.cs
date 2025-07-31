using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Services.Database.Entities;

namespace eCommerce.Models.Entities;

[Table("UnitOfMeasures")]
public class UnitOfMeasure
{
    [Key]
    public int UnitOfMeasureId { get; set; }

    [Required, MaxLength(10)]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
