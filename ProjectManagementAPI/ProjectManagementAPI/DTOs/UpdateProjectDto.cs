namespace ProjectManagementAPI.DTOs
{
    public class UpdateProjectDto
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string ProjectCode { get; set; } = string.Empty;

        public string Manager { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal Budget { get; set; }

        public string Notes { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}