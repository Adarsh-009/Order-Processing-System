using System;
using System.Collections.Generic;

namespace OrderProcessingSystem.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
