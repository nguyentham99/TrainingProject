using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TrainingProject.Entities
{
    public class Status
    {
        public Guid Id { get; set; }
        public string StatusName { get; set; }
        public ICollection<AssignedTask> Tasks { get; set; }
    }
}
