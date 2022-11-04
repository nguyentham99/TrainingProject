using System;

namespace TrainingProject.Models
{
    public class UpdateTaskModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
