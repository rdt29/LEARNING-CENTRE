using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LEARNING_CENTRE_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyServices _technologyServices;
        public TechnologyController(ITechnologyServices technologyServices)
        {
            _technologyServices = technologyServices;
        }

        [HttpPost("add-technology"), Authorize(Roles = "PM,Mentor,CTO")]
        public async Task<ActionResult> AddTechnology([FromForm] TechnologyRequestModel technologyRequestModel)
        {
           await _technologyServices.AddTechnologyAsync(technologyRequestModel);
            return Ok("Technology Added Successfully");
        }

        //[HttpGet("view-technology")]
        //public async Task<ActionResult> GetTechnology()
        //{
        //    var tech = await _technologyServices.GetTechnologyAsync();
        //    return Ok(tech);
        //}
        [HttpGet("view-technology"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<ActionResult> GetTechnology(int page=1,int pageSize=25)
        {
            var technology = await _technologyServices.GetTechnologyAsync(page, pageSize);
            return Ok(technology);
        }
        [HttpGet("view-technology-by-id"), Authorize(Roles = "PM,Mentor,Trainee,CTO")]
        public async Task<ActionResult> GetTechnology(int Id)
        {
            var technology= await _technologyServices.GetTechnologyByIdAsync(Id);
            return Ok(technology);
        }

        [HttpDelete("delete-technology"), Authorize(Roles = "PM,Mentor,CTO")]
        public async Task<ActionResult> DeleteTechnology(int Id,TechnologyRequestModel technologyRequestModel)
        {
            await _technologyServices.DeleteTechnologyAsync(Id, technologyRequestModel);
            return Ok("Technology Deleted Successfully.");
        }

        [HttpPut,Authorize(Roles = "PM,Mentor,CTO")]
        public async Task<ActionResult> UpdateTechnology(int Id,TechnologyUpdateRequestModel technologyUpdateRequestModel)
        {
            await _technologyServices.UpdateTechnologyAsync(Id, technologyUpdateRequestModel);
            return Ok("Technology updated successfully.");
        }

    }
}
