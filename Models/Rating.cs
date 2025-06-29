namespace EcommerceProAPI.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public string UserId { get; set; } = "";
        public ApplicationUser? User { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Stars { get; set; } // 1-5
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
