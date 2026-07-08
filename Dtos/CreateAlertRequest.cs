namespace SafeTrack.AuthService.Dtos
{
    public class CreateAlertRequest
    {
        public string Type { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}