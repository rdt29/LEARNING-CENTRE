using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Services.Helper.Implementation;
using LearningCentre.Core.Services.Helper.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LEARNING_CENTRE_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskEvaluationController : ControllerBase
    {
        private readonly ITaskEvaluationServices _taskEvaluationServices;
        private readonly IMailServices _mailServices;

        public TaskEvaluationController(ITaskEvaluationServices taskEvaluationServices, IMailServices mailServices)
        {
            _taskEvaluationServices = taskEvaluationServices;
            _mailServices = mailServices;

        }
        [HttpPost("add-taskevaluation")]
        public async Task<IActionResult> AddTaskEvaluation([FromForm] TaskEvaluationRequestModel taskEvaluationRequestModel)
        {
            await _taskEvaluationServices.AddTaskEvaluationAsync(taskEvaluationRequestModel);
            return Ok("Task Evaluation Added Successfully.");
        }

        //[HttpGet("view-taskevaluation")]
        //public async Task<IActionResult> GetTaskEvaluation()
        //{
        //    var t=await _taskEvaluationServices.GetTaskEvaluationAsync();
        //    return Ok(t);
        //}

        [HttpGet("view-taskevaluation"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<ActionResult> GetTaskEvaluation(int page=1,int pageSize=25)
        {
            var taskEvaluation= await _taskEvaluationServices.GetTaskEvaluationAsync(page,pageSize);
            return Ok(taskEvaluation);
        }
        [HttpGet("view-taskevaluation-by-id"), Authorize(Roles = "Trainee,Mentor,PM,CTO")]
        public async Task<IActionResult> GetTaskEvaluationById(int Id)
        {
            var taskEvaluation = await _taskEvaluationServices.GetTaskEvaluationByIdAsync(Id);
            return Ok(taskEvaluation);
        }

        [HttpDelete("delete-taskevaluation"), Authorize(Roles = "PM,Mentor,CTO")]
        public async Task<IActionResult> DeleteTaskEvaluation(int Id,TaskEvaluationRequestModel taskEvaluationRequestModel)
        {
            await _taskEvaluationServices.DeleteTaskEvaluationAsync(Id, taskEvaluationRequestModel);
            return Ok("Task Evaluation Deleted Successfully.");
        }

        [HttpPut("update-taskevaluation"), Authorize(Roles = "PM,Mentor,CTO")]
        public async Task<IActionResult> UpdateTaskEvaluation(int Id,TaskEvaluationRequestModel taskEvaluationRequestModel)
        {
            await _taskEvaluationServices.UpdateTaskEvaluationAsync(Id, taskEvaluationRequestModel);
            return Ok("Task Evaluation Updated Successfully.");
        }


        [HttpPost ,Authorize(Roles = "PM,Mentor,CTO")]
        public IActionResult SendEmail([FromForm]EmailRequestModel request)
        {
            _mailServices.SendEmail(request);
            return Ok();
        }

    }
}
