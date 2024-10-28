using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Names { get; set; }

    public virtual ICollection<ProductsInCategory> ProductsInCategories { get; set; } = new List<ProductsInCategory>();
}
