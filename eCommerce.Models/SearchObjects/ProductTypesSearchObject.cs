using System;

namespace eCommerce.Models.SearchObjects;

public class ProductTypesSearchObject : BaseSearchObject
{
    public string? NameGTE { get; set; }
}
