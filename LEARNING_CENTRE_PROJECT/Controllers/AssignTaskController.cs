using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LEARNING_CENTRE_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignTaskController : ControllerBase
    {
        private readonly IAssignTaskServices _assignTaskServices;

        public AssignTaskController(IAssignTaskServices assignTaskServices)
        {
            _assignTaskServices = assignTaskServices;
        }

        [HttpPost("add-assigntask"),Authorize(Roles ="Mentor,PM,CTO")]
        public async Task<IActionResult> AddAssignTask(AssignTaskRequestModel[] assignTaskRequestModel)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(id);

            foreach (var i in assignTaskRequestModel)
            {
                await _assignTaskServices.AddAssignTaskAsync(i , userId);
            }

            return Ok("Assign Task Added Successfully.");
        }

        [HttpGet("view-assigntask"),Authorize(Roles = "Mentor,PM,CTO")]
        public async Task<ActionResult> GetAssignTask(int page = 1, int pageSize = 25)
        {
            var assignTask = await _assignTaskServices.GetAssignTaskAsync(page, pageSize);
            return Ok(assignTask);
        }

        [HttpGet("view-assigntask-by-id"), Authorize(Roles = "Trainee,Mentor,PM,CTO")]
        public async Task<IActionResult> GetAssignTaskById(int id)
        {
         //   var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
           // var a = int.Parse(claimsIdentity.Claims.ToList()[1].Value);

            var assignTask = await _assignTaskServices.GetAssignTaskByIdAsync(id);
            return Ok(assignTask);
        }

        [HttpDelete("delete-assigntask"), Authorize(Roles = "Mentor,PM,CTO")]
        public async Task<IActionResult> DeleteAssignTask(int UserId,int TaskId)
        {
            await _assignTaskServices.DeleteAssignTaskAsync(UserId,TaskId);
            return Ok("Assign Task Deleted Successfully.");
        }

        [HttpPut("update-assigntask"), Authorize(Roles = "Mentor,PM,CTO")]
        public async Task<IActionResult> UpdateAssignTask(AssignTaskRequestModel a)
        {
            await _assignTaskServices.UpdateAssignTaskAsync(a);
            return Ok("Assign Task Updated Successfully");
        }
    }
}