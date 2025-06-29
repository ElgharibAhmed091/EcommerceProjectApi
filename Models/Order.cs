namespace EcommerceProAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; } = "";
        public ApplicationUser? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Pending"; // أو "Paid", "Canceled"
        public ICollection<OrderItem>? Items { get; set; }
    }
}
