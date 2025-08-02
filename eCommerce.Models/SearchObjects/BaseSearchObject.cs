using System;

namespace eCommerce.Models.SearchObjects;

public abstract class BaseSearchObject
{
    public int? Page { get; set; } = null;
    public int? PageSize { get; set; } = null;
}
