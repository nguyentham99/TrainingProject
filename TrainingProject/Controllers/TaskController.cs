using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Entities;
using TrainingProject.Interface;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private ILogger _logger;
        private ITaskService _iTaskService;


        public TaskController(ILogger<TaskController> logger, ITaskService iTaskService)
        {
            _logger = logger;
            _iTaskService = iTaskService;

        }
        [HttpPost]
        public void Create(CreateTaskModel createTaskModel)
        {
           _iTaskService.CreateTask(createTaskModel);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _iTaskService.GetAll();
            if (tasks == null) return BadRequest(new { message = "Data Emptys" });
            return Ok(tasks);
        }
        [HttpPut]
        public IActionResult Update(AssignedTask updateTaskModel)
        {
            var task = _iTaskService.UpdateTask(updateTaskModel);
            if (task == false) 
                return BadRequest(new { message = "Update fail" });

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var res = _iTaskService.DelateTask(id);
            if(res == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
