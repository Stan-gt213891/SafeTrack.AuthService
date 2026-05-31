namespace SafeTrack.AuthService.Models
{
    public class Alert
    {
        public int Id { get; set; }

        public string Type { get; set; } = "Pánico";

        public string Message { get; set; } = string.Empty;

        public string Status { get; set; } = "Activa";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}