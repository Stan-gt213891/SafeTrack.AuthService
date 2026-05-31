namespace SafeTrack.AuthService.DTOs
{
    public class CreateFamilyMemberRequest
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Role { get; set; } = "Dependiente";
    }
}