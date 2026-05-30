using Microsoft.AspNetCore.Mvc;
using SafeTrack.AuthService.Data;
using SafeTrack.AuthService.DTOs;
using SafeTrack.AuthService.Models;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new
                {
                    message = "FullName, Email and Password are required"
                });
            }

            var emailExists = _context.Users.Any(u => u.Email == request.Email);

            if (emailExists)
            {
                return BadRequest(new
                {
                    message = "Email is already registered"
                });
            }

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "Tutor",
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new
            {
                message = "User registered successfully",
                userId = user.Id,
                email = user.Email
            });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new
                {
                    message = "Email and Password are required"
                });
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password"
                });
            }

            var passwordValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash
            );

            if (!passwordValid)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password"
                });
            }

            return Ok(new
            {
                message = "Login successful",
                token = "jwt-token-generated",
                userId = user.Id,
                fullName = user.FullName,
                email = user.Email,
                role = user.Role
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

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new
            {
                message = "Logout successful"
            });
        }
    }
}