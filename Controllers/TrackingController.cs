using Microsoft.AspNetCore.Mvc;
using SafeTrack.AuthService.Data;
using SafeTrack.AuthService.DTOs;
using SafeTrack.AuthService.Models;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/tracking")]
    public class TrackingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrackingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("location")]
        public IActionResult SendLocation([FromBody] SendLocationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Latitude) ||
                string.IsNullOrWhiteSpace(request.Longitude))
            {
                return BadRequest(new
                {
                    message = "Latitude and Longitude are required"
                });
            }

            var location = new Location
            {
                DependentId = request.DependentId,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CreatedAt = DateTime.UtcNow
            };

            _context.Locations.Add(location);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Location registered successfully",
                location
            });
        }

        [HttpGet("{dependentId}")]
        public IActionResult GetLocation(int dependentId)
        {
            var location = _context.Locations
                .Where(l => l.DependentId == dependentId)
                .OrderByDescending(l => l.CreatedAt)
                .FirstOrDefault();

            if (location == null)
            {
                return Ok(new
                {
                    dependentId = dependentId,
                    latitude = "-12.0464",
                    longitude = "-77.0428",
                    status = "Ruta segura"
                });
            }

            return Ok(new
            {
                dependentId = location.DependentId,
                latitude = location.Latitude,
                longitude = location.Longitude,
                status = "Ruta segura",
                createdAt = location.CreatedAt
            });
        }
    }
}