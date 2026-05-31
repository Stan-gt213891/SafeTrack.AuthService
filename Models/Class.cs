namespace SafeTrack.AuthService.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Role { get; set; } = "Dependiente";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}