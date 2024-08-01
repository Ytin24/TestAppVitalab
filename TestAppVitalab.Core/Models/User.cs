using System;
using System.Collections.Generic;

namespace TestAppVitalab.Api.DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

}
public record UserDTO
{
    public int UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string UserLogin { get; set; } = string.Empty;

    public string UserPassword { get; set; } = string.Empty;

}