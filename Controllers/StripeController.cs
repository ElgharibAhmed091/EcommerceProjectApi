using EcommerceProAPI.Data;
using EcommerceProAPI.DTOs;
using EcommerceProAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace EcommerceProAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly StripeService _stripe;

        public StripeController(ApplicationDbContext context, StripeService stripe)
        {
            _context = context;
            _stripe = stripe;
        }

        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] StripeCheckoutDto dto)
        {
            var productIds = dto.Products.Select(p => p.ProductId).ToList();

            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            if (!products.Any()) return BadRequest("No valid products.");

            var lineItems = products.Select(p =>
            {
                var quantity = dto.Products.First(x => x.ProductId == p.Id).Quantity;

                return new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = (long)(p.Price * 100),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = p.Name
                        }
                    },
                    Quantity = quantity
                };
            }).ToList();

            var options = new SessionCreateOptions
            {
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7072/api/stripe/payment-success",
                CancelUrl = "https://localhost:7072/api/stripe/payment-cancel"
            };

            var service = new SessionService();
            var session = service.Create(options);

            return Ok(new { url = session.Url });
        }

        [HttpGet("payment-success")]
        public IActionResult PaymentSuccess()
        {
            return Ok("✅ الدفع تم بنجاح!");
        }

        [HttpGet("payment-cancel")]
        public IActionResult PaymentCancel()
        {
            return Ok("❌ الدفع تم إلغاؤه.");
        }

    }
}
