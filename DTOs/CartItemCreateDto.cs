namespace EcommerceProAPI.DTOs
{
    public class CartItemCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
       // public string? UserId { get; set; } // لازم يكون موجود لو هتبعت يدويًا
    }
}
