namespace ProjectManagementAPI.DTOs
{
    public class AddUserDto
    {
        public string UserName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;
    }
}