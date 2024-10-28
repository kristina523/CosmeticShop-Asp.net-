using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; } = new List<ProductsInOrder>();

    public virtual User? User { get; set; }
}
