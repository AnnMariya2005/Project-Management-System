namespace ProjectManagementAPI.DTOs
{
    public class UpdateTaskDto
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public string AssignedTo { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public int EstimatedHours { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}