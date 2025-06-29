using AutoMapper;
using EcommerceProAPI.Data;
using EcommerceProAPI.DTOs;
using EcommerceProAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcommerceProAPI.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemReadDto>>> GetMyCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = await _context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<CartItemReadDto>>(cartItems));
        }

        // POST: api/cart
        [HttpPost]
        public async Task<ActionResult> AddToCart(CartItemCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in.");
            }

            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
            }
            else
            {
                var cartItem = _mapper.Map<CartItem>(dto);
                cartItem.UserId = userId;
                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return Ok("Item added to cart.");
        }


        // DELETE: api/cart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (item == null) return NotFound();

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Item removed from cart.");
        }
    }
}
