namespace ProjectManagementAPI.DTOs
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public string? Token { get; set; }

        public string? Role { get; set; }
    }
}