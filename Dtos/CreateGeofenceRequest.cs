namespace SafeTrack.AuthService.DTOs
{
    public class CreateGeofenceRequest
    {
        public string Name { get; set; } = string.Empty;

        public int Radius { get; set; }

        public string Status { get; set; } = "Activa";
    }
}