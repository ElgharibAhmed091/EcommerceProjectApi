namespace EcommerceProAPI.DTOs
{
    public class DashboardStatsDto
    {
        public int TotalUsers { get; set; }
        public int TotalOrders { get; set; }
        public int PaidOrders { get; set; }
        public int PendingOrders { get; set; }
        public int CanceledOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalProducts { get; set; }
        public string? TopProduct { get; set; }
    }
}
