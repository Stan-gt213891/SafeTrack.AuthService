using Microsoft.AspNetCore.Mvc;
using SafeTrack.AuthService.Data;
using SafeTrack.AuthService.DTOs;
using SafeTrack.AuthService.Models;

namespace SafeTrack.AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/family-members")]
    public class FamilyMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FamilyMembersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFamilyMembers()
        {
            var members = _context.FamilyMembers
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            return Ok(members);
        }

        [HttpPost]
        public IActionResult CreateFamilyMember([FromBody] CreateFamilyMemberRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) || request.Age <= 0)
            {
                return BadRequest(new
                {
                    message = "FullName and Age are required"
                });
            }

            var member = new FamilyMember
            {
                FullName = request.FullName,
                Age = request.Age,
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };

            _context.FamilyMembers.Add(member);
            _context.SaveChanges();

            return Ok(member);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFamilyMember(int id)
        {
            var member = _context.FamilyMembers
                .FirstOrDefault(m => m.Id == id);

            if (member == null)
            {
                return NotFound(new
                {
                    message = "Family member not found"
                });
            }

            _context.FamilyMembers.Remove(member);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Family member deleted successfully"
            });
        }
    }
}