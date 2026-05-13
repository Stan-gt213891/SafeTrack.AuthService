using Microsoft.AspNetCore.Mvc;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok(new
            {
                message = "User registered successfully"
            });
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok(new
            {
                message = "Login successful",
                token = "jwt-token-generated"
            });
        }

        [HttpGet("validate-token")]
        public IActionResult ValidateToken()
        {
            return Ok(new
            {
                message = "Token valid"
            });
        }
    }
}