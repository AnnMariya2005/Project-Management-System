namespace ProjectManagementAPI.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? Token { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}