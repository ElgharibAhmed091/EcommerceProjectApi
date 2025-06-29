using EcommerceProAPI.Data;
using EcommerceProAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("stats")]
        public async Task<ActionResult<DashboardStatsDto>> GetStats()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalOrders = await _context.Orders.CountAsync();
            var paidOrders = await _context.Orders.CountAsync(o => o.Status == "Paid");
            var pendingOrders = await _context.Orders.CountAsync(o => o.Status == "Pending");
            var canceledOrders = await _context.Orders.CountAsync(o => o.Status == "Canceled");
            var totalRevenue = await _context.Orders
                .Where(o => o.Status == "Paid")
                .SumAsync(o => o.TotalPrice);

            var totalProducts = await _context.Products.CountAsync();

            // Optional: أكثر منتج مبيعًا
            var topProduct = await _context.OrderItems
                .GroupBy(i => i.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalQuantity = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(g => g.TotalQuantity)
                .Join(_context.Products,
                      g => g.ProductId,
                      p => p.Id,
                      (g, p) => p.Name)
                .FirstOrDefaultAsync();

            return Ok(new DashboardStatsDto
            {
                TotalUsers = totalUsers,
                TotalOrders = totalOrders,
                PaidOrders = paidOrders,
                PendingOrders = pendingOrders,
                CanceledOrders = canceledOrders,
                TotalRevenue = totalRevenue,
                TotalProducts = totalProducts,
                TopProduct = topProduct
            });
        }
    }
}
