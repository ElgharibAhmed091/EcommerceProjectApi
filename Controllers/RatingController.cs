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
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RatingController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST: api/rating
        [HttpPost]
        public async Task<IActionResult> AddRating(RatingCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // كل مستخدم يقيم مرة واحدة فقط
            var exists = await _context.Ratings.AnyAsync(r => r.UserId == userId && r.ProductId == dto.ProductId);
            if (exists)
                return BadRequest("You already rated this product.");

            var rating = _mapper.Map<Rating>(dto);
            rating.UserId = userId!;

            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return Ok("Rating submitted.");
        }

        // GET: api/rating/product/5
        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RatingReadDto>>> GetRatingsForProduct(int productId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.ProductId == productId)
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<RatingReadDto>>(ratings));
        }

        // GET: api/rating/product/5/average
        [HttpGet("product/{productId}/average")]
        [AllowAnonymous]
        public async Task<ActionResult<decimal>> GetAverageRating(int productId)
        {
            var avg = await _context.Ratings
                .Where(r => r.ProductId == productId)
                .AverageAsync(r => (decimal?)r.Stars) ?? 0;

            return Ok(Math.Round(avg, 2));
        }
    }
}
