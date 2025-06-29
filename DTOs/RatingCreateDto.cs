namespace EcommerceProAPI.DTOs
{
    public class RatingCreateDto
    {
        
            public int ProductId { get; set; }
            public int Stars { get; set; } // 1-5
            public string? Comment { get; set; }
        }

 }
