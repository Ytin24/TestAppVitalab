using System;
using System.Collections.Generic;

namespace TestAppVitalab.Api.DAL.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
public record ProductDTO
{
    public int ProductId { get; set; }

    public string Name { get; set; }= string.Empty;

    public decimal Price { get; set; }
}