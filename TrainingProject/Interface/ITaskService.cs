using System;
using System.Collections.Generic;
using TrainingProject.Entities;
using TrainingProject.Models;

namespace TrainingProject.Interface
{
    public interface ITaskService
    {
        List<AssignedTask> GetAll();
        void CreateTask(CreateTaskModel createTaskModel);
        bool UpdateTask(AssignedTask assignedTask);
        bool DelateTask(Guid id);
    }
}
