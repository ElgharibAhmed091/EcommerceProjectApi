namespace EcommerceProAPI.DTOs
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "";
        public decimal TotalPrice { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
    }
}
