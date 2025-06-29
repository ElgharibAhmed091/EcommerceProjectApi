namespace EcommerceProAPI.DTOs
{
    public class ProductFilterDto
    {
        public int? CategoryId { get; set; }
        public string? Search { get; set; }
        public string? SortBy { get; set; } // "price_asc", "price_desc", "rating"
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }

}
