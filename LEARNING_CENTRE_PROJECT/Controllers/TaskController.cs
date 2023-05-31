using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LEARNING_CENTRE_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;
        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        //[HttpGet("get-all-task")]
        //public async Task <ActionResult> Get()
        //{
        //    var task = await _taskServices.GetTaskAsync();
        //    return Ok(task);
        //}
        [HttpGet("view-task"), Authorize(Roles = "PM,Mentor,CTO")]
        public async Task<ActionResult> GetTask(int page=1,int pageSize=25)
        {
            var task = await _taskServices.GetTaskAsync(page, pageSize);
            return Ok(task);
        }

        [HttpGet("get-task-byid"), Authorize(Roles = "PM,Mentor,CTO")]
        public async Task <TaskResponseModel> GetId(int id)
        {
            var task = await _taskServices.GetTaskByIdAsync(id);
            return (task);
        }
        [HttpPost("add-task"), Authorize(Roles = "PM,Mentor,CTO")]
        public async Task<ActionResult>AddTask([FromForm]TaskRequestModelAdd taskRequestModelAdd)
        {

             await _taskServices.AddTaskAsync(taskRequestModelAdd);
            return Ok(taskRequestModelAdd);
        }
        

    }
}
