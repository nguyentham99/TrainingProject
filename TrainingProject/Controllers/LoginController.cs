using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainingProject.Interface;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogger _logger;
        private ILoginService _iLoginService;


        public LoginController(ILogger<TaskController> logger, ILoginService iLoginService)
        {
            _logger = logger;
            _iLoginService = iLoginService;

        }
        [HttpPost]
        public void Register(RegisterModels registerModels)
        {
            _iLoginService.Register(registerModels);
        }
    }
}
