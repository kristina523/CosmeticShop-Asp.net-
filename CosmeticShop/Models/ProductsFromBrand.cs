using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class ProductsFromBrand
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Product? Product { get; set; }
}
