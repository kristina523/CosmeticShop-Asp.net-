﻿using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class ProductsInCategory
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Product? Product { get; set; }
}
