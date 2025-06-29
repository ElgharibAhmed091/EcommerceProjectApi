namespace EcommerceProAPI.DTOs
{
    public class StripeCheckoutDto
    {
        public List<ProductOrderDto> Products { get; set; } = new();
    }

    public class ProductOrderDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
