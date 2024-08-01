using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mapster;
using TestAppVitalab.Api.DAL.Models;

namespace TestAppVitalab.Api.DAL.Models;


public class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}

public record OrderDTO
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
}