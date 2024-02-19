using System;
using System.Collections.Generic;

namespace OrderProcessingSystem.Models;

public partial class OrderProduct
{
    public int OrderDetailId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Rate { get; set; }

    public int? Qty { get; set; }

    public string? Size { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
