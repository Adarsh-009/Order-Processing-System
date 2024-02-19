using System;
using System.Collections.Generic;

namespace OrderProcessingSystem.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public int CustomerId { get; set; }
        public string CustomerAddress { get; set; } = null!;    
        public string CustomerContact { get; set; } = null!;

        //public OrderProductDto Product { get; set; }

        public List<OrderProductDto>? Products { get; set; }
    }
}
