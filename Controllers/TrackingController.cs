using Microsoft.AspNetCore.Mvc;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/tracking")]
    public class TrackingController : ControllerBase
    {
        [HttpPost("location")]
        public IActionResult SendLocation()
        {
            return Ok(new
            {
                message = "Location registered successfully"
            });
        }

        [HttpGet("{dependentId}")]
        public IActionResult GetLocation(int dependentId)
        {
            return Ok(new
            {
                dependentId = dependentId,
                latitude = "-12.0464",
                longitude = "-77.0428",
                status = "Ruta segura"
            });
        }
    }
}
