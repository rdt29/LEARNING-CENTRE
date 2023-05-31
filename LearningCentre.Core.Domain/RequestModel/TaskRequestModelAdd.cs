using Microsoft.AspNetCore.Http;

namespace LearningCentre.Core.Domain.RequestModel
{
    public class TaskRequestModelAdd
    {


        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string ?TaskDescription { get; set; }
        public IFormFile? files { get; set; }

       
    }
}
