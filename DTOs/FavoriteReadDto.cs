namespace EcommerceProAPI.DTOs
{
    public class FavoriteReadDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; }
    }
}
