using System;
using System.Collections.Generic;

namespace TestAppVitalab.Api.DAL.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

public record OrderItemDTO
{
    public int OrderItemId { get; set; }

    public int Quantity { get; set; }

    public ProductDTO Product { get; set; } = null!;
}