namespace ProjectManagementAPI.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string ProjectCode { get; set; } = string.Empty;

        public string Manager { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Budget { get; set; }

        public string Notes { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}