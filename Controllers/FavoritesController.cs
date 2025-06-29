using AutoMapper;
using EcommerceProAPI.Data;
using EcommerceProAPI.DTOs;
using EcommerceProAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcommerceProAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FavoritesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/favorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteReadDto>>> GetMyFavorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favorites = await _context.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Product)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<FavoriteReadDto>>(favorites));
        }

        // POST: api/favorites/5
        [HttpPost("{productId}")]
        public async Task<IActionResult> AddToFavorites(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var exists = await _context.Favorites
                .AnyAsync(f => f.UserId == userId && f.ProductId == productId);

            if (exists) return BadRequest("Product already in favorites.");

            var favorite = new Favorite
            {
                UserId = userId!,
                ProductId = productId
            };

            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return Ok("Product added to favorites.");
        }

        // DELETE: api/favorites/5
        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromFavorites(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var favorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);

            if (favorite == null) return NotFound();

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return Ok("Product removed from favorites.");
        }
    }
}
