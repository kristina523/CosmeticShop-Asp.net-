using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string? Names { get; set; }

    public virtual ICollection<ProductsFromBrand> ProductsFromBrands { get; set; } = new List<ProductsFromBrand>();
}
