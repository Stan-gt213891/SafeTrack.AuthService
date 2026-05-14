using Microsoft.AspNetCore.Mvc;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/alerts")]
    public class AlertController : ControllerBase
    {
        [HttpPost("panic")]
        public IActionResult PanicAlert()
        {
            return Ok(new
            {
                message = "Emergency alert activated"
            });
        }

        [HttpGet]
        public IActionResult GetAlerts()
        {
            return Ok(new
            {
                message = "Alerts retrieved successfully"
            });
        }
    }
}