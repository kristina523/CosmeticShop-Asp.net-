using System;
using System.Collections.Generic;

namespace CosmeticShop.Models;

public partial class Price
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? Price1 { get; set; }

    public string? Dates { get; set; }

    public virtual Product? Product { get; set; }
}
