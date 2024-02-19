namespace OrderProcessingSystem.DTO
{
    public class OrderProductDto
    {
        public int OrderDetailId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Rate { get; set; }
        public int? Qty { get; set; }
        public string? Size { get; set; }
        public int? OrderId { get; set; }
    }

}
