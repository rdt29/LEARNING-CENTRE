using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LEARNING_CENTRE_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //[HttpGet("get-user")]
        //public async Task<ActionResult> GetUser()
        //{
        //    var u1 = await _service.GetUserAsync();
        //    return Ok(u1);
        //}
        [HttpGet("view-user"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<ActionResult> GetUser(int page = 1, int pageSize = 25)
        {
            var user = await _service.GetUserAsync(page, pageSize);
            return Ok(user);
        }

        [HttpGet("getid-user"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<UserResponseMOdel> GetUserById(int Id)
        {
            var user = await _service.GetUserByIdAsync(Id);
            return (user);
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromForm] UserRequestModel userRequestModel)
        {
            var ab = await _service.AddUserAsync(userRequestModel);
            return Ok(ab);
        }

        [HttpPut("update-user"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<ActionResult> UpdateUser(int Id, UserUpdateReqModel userUpdateReqModel)
        {
            await _service.UpdateUserAsync(Id, userUpdateReqModel);
            return Ok("Update Successfully");
        }

        [HttpDelete("delete-user"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<ActionResult> DeleteUser(int Id, UserDeleteRequestModel UserDeleteRequestModel)
        {
            await _service.DeleteUserAsync(Id, UserDeleteRequestModel);
            return Ok("Deleted Sucessfully");
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> UserLogin(UserLoginReqModel userLoginReqModel)
        {
            var user = (await _service.UserLogin(userLoginReqModel));
            return Ok(user);
        }

        [HttpGet("get-assign-task"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<IActionResult> GetTask(int Id)
        {
            var task = await _service.GetAssignTaskAsync(Id);
            return Ok(task);
        }
    }
}