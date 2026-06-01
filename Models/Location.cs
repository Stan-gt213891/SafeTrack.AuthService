namespace SafeTrack.AuthService.Models
{
    public class Location
    {
        public int Id { get; set; }

        public int DependentId { get; set; } = 1;

        public string Latitude { get; set; } = string.Empty;

        public string Longitude { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}