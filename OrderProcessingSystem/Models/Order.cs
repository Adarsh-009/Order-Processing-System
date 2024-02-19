using System;
using System.Collections.Generic;

namespace OrderProcessingSystem.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal Total { get; set; }

    public decimal Discount { get; set; }

    public int CustomerId { get; set; }

    public string CustomerAddress { get; set; } = null!;

    public string CustomerContact { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
