namespace SafeTrack.AuthService.DTOs
{
    public class SendLocationRequest
    {
        public int DependentId { get; set; } = 1;

        public string Latitude { get; set; } = string.Empty;

        public string Longitude { get; set; } = string.Empty;
    }
}
