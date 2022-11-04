using System;

namespace TrainingProject.Entities
{
    public class AssignedTask
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
    }
}
