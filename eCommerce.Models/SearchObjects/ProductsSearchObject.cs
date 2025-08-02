using System;

namespace eCommerce.Models.SearchObjects;

public class ProductsSearchObject : BaseSearchObject
{
    public string? FTS { get; set; } = string.Empty;
}
