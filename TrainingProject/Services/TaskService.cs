using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Entities;
using TrainingProject.Interface;
using TrainingProject.Models;

namespace TrainingProject.Services
{
    public class TaskService : ITaskService
    {
        private readonly TrainingDbContext _context;
        public TaskService(TrainingDbContext context)
        {
            _context = context;
        }

        public List<AssignedTask> GetAll()
        {
            var tasks = _context.AssignedTask.ToList();

            return tasks;
        }
        public void CreateTask(CreateTaskModel createTaskModel)
        {
            try
            {
                var task = new AssignedTask()
                {
                    Id = Guid.NewGuid(),
                    Subject = createTaskModel.Subject,
                    Description = createTaskModel.Description,
                    StartDate = createTaskModel.StartDate,
                    DueDate = createTaskModel.DueDate,
                    CreateAt = DateTime.Now,
                    StatusId = createTaskModel.statusId
                };
                _context.AssignedTask.Add(task);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException(paramName: nameof(createTaskModel), message: e.Message);
            }
        }
        public bool UpdateTask(AssignedTask assignedTask)
        {
            var task = _context.AssignedTask.Where(x => x.Id == assignedTask.Id).FirstOrDefault();
            if(task != null)
            {
                task.Subject = assignedTask.Subject;
                task.Description = assignedTask.Description;
                task.StartDate = assignedTask.StartDate;
                task.DueDate = assignedTask.DueDate; 
                task.UpdateAt = DateTime.Now;
                task.Status = assignedTask.Status;

                _context.AssignedTask.Update(task);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DelateTask(Guid id)
        {
            var task = _context.AssignedTask.Where(x => x.Id == id).FirstOrDefault();
            if (task != null)
            {
                _context.Remove(task);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
