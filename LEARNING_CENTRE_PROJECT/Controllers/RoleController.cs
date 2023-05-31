using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LEARNING_CENTRE_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _service;

        public RoleController(IRoleServices service)
        {
            _service = service;
        }

        [HttpGet("get-role"), Authorize(Roles = "Trainee,Mentor,PM,CTO")]
        public async Task<ActionResult> GetRole()
        {
            var role = await _service.GetRoleAsync();
            return Ok(role);
        }

        [HttpPost("post-role"), Authorize(Roles = "CTO")]
        public async Task<ActionResult> AddRole([FromForm] RoleRequestModel roleRequestModel)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(id);

            var role = await _service.AddRoleAsync(roleRequestModel , userId);
            return Ok(role);
        }

        //[HttpGet("view-roles")]
        //public async Task<ActionResult> GetRole(int page=1,int pageSize=25)
        //{
        //    var role=await _service.GetRoleAsync(page,pageSize);
        //    return Ok(role);
        //}

        [HttpGet("TeamList"), Authorize(Roles = "Trainee,Mentor,PM,CTO")]
        public async Task<IActionResult> Team()
        {
            var team = await _service.Team();
            return Ok(team);
        }

        [HttpPost("assign-team"), Authorize(Roles = "Mentor,PM,CTO")]
        public async Task<IActionResult> AddTeam(int SuperiorId, int TranieeId)
        {
            var team = await _service.AssignTeamAsync(SuperiorId, TranieeId);
            return Ok(team);
        }
    }
}