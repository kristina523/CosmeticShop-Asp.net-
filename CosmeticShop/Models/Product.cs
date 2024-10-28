using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Names { get; set; }

    public string? Descriptions { get; set; }

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<ProductsFromBrand> ProductsFromBrands { get; set; } = new List<ProductsFromBrand>();

    public virtual ICollection<ProductsInCategory> ProductsInCategories { get; set; } = new List<ProductsInCategory>();

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; } = new List<ProductsInOrder>();
}
