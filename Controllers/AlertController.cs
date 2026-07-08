using SafeTrack.AuthService.Dtos;
using Microsoft.AspNetCore.Mvc;
using SafeTrack.AuthService.Data;
using SafeTrack.AuthService.Models;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/alerts")]
    public class AlertController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAlerts()
        {
            var alerts = _context.Alerts
                .OrderByDescending(a => a.CreatedAt)
                .ToList();

            return Ok(alerts);
        }

        [HttpPost("panic")]
        public IActionResult PanicAlert()
        {
            var alert = new Alert
            {
                Type = "Pánico",
                Message = "Botón de pánico activado",
                Status = "Activa",
                CreatedAt = DateTime.UtcNow
            };

            _context.Alerts.Add(alert);
            _context.SaveChanges();

            return Ok(alert);
        }
        [HttpPost("geofence")]
        public IActionResult GeofenceAlert([FromBody] CreateAlertRequest request)
        {
            var alert = new Alert
            {
                Type = request.Type,
                Message = request.Message,
                Status = "Activa",
                CreatedAt = DateTime.UtcNow
            };

            _context.Alerts.Add(alert);
            _context.SaveChanges();

            return Ok(alert);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAlert(int id)
        {
            var alert = _context.Alerts.FirstOrDefault(a => a.Id == id);

            if (alert == null)
            {
                return NotFound(new
                {
                    message = "Alert not found"
                });
            }

            _context.Alerts.Remove(alert);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Alert deleted successfully"
            });
        }
    }
}