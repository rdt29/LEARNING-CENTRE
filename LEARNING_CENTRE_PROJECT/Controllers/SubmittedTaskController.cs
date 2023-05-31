using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LEARNING_CENTRE_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmittedTaskController : ControllerBase
    {
        private readonly ISubmittedTaskServices _service;

        public SubmittedTaskController(ISubmittedTaskServices service)
        {
            _service = service;
        }

        [HttpGet("get-submittedtask"), Authorize(Roles = "Trainee,Mentor,PM,CTO")]
        public async Task<ActionResult> GetSubmittedTask()
        {
            var submittask = await _service.GetSubmitTaskAsync();
            return Ok(submittask);
        }

        [HttpGet("get-submittedtask-byid"), Authorize(Roles = "Trainee,Mentor,PM,CTO")]
        public async Task<ActionResult> GetTask(int Id)
        {
            var submittask = await _service.GetSubmittedTaskByIdAsync(Id);
            return Ok(submittask);
        }

        [HttpPost("add-submittedtask"), Authorize(Roles = "Trainee")]
        public async Task<SubmittedTaskResponseModel> AddTask([FromForm] SubmittedTaskRequestModel submittedTaskRequestModel)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(id);
            return await _service.AddSubmitTaskAsync(submittedTaskRequestModel, userId);
        }

        [HttpPut("update-submittedtask"), Authorize(Roles = "Trainee")]
        public async Task<ActionResult> UpdateSubmittedTask(int Id, SubmittedTaskRequestModel submittedTaskRequestModel)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(id);
            await _service.UpdateSubmittedTaskAsync(Id, submittedTaskRequestModel, userId);
            return Ok("Submitted Task is Updated Successfully.");
        }

        [HttpDelete("delete-submittedtask"), Authorize(Roles = "Trainee")]
        public async Task<ActionResult> DeleteSubmittedTask(int Id, SubmittedTaskRequestModel submittedTaskRequestModel)
        {
            await _service.DeleteSubmittedTaskAsync(Id, submittedTaskRequestModel);
            return Ok("Submitted Task is Deleted Successfully.");
        }
    }
}