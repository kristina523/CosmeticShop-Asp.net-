using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Passwords { get; set; }

    public string? Roles { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
