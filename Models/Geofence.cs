namespace SafeTrack.AuthService.Models
{
    public class Geofence
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Radius { get; set; }

        public string Status { get; set; } = "Activa";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}