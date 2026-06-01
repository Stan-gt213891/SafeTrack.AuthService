using Microsoft.AspNetCore.Mvc;
using SafeTrack.AuthService.Data;
using SafeTrack.AuthService.DTOs;
using SafeTrack.AuthService.Models;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/geofences")]
    public class GeofencesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GeofencesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetGeofences()
        {
            var geofences = _context.Geofences
                .OrderByDescending(g => g.CreatedAt)
                .ToList();

            return Ok(geofences);
        }

        [HttpPost]
        public IActionResult CreateGeofence([FromBody] CreateGeofenceRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || request.Radius <= 0)
            {
                return BadRequest(new
                {
                    message = "Name and Radius are required"
                });
            }

            var geofence = new Geofence
            {
                Name = request.Name,
                Radius = request.Radius,
                Status = request.Status,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CreatedAt = DateTime.UtcNow
            };

            _context.Geofences.Add(geofence);
            _context.SaveChanges();

            return Ok(geofence);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGeofence(int id)
        {
            var geofence = _context.Geofences
                .FirstOrDefault(g => g.Id == id);

            if (geofence == null)
            {
                return NotFound(new
                {
                    message = "Geofence not found"
                });
            }

            _context.Geofences.Remove(geofence);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Geofence deleted successfully"
            });
        }
    }
}