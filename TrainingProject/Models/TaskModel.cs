using System;
using TrainingProject.Entities;

namespace TrainingProject.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Status Status { get; set; }
    }
}
