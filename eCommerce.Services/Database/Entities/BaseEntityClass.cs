using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace eCommerce.Services.Database.Entities;

public abstract class BaseEntityClass
{
    public long CreatedAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    public long? UpdatedAt { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }
}
