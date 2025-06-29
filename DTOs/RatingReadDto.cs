namespace EcommerceProAPI.DTOs
{
    public class RatingReadDto
    {

        public string UserName { get; set; } = "";
        public int Stars { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
