using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.RequestModel
{
    public class SubmittedTaskRequestModel
    {
         //public int UserId { get; set; }
        public int AssignTaskId { get; set; }

        public string Status { get; set; }

       

        public List<IFormFile>? Files { get; set; }

        public DateTimeOffset Submission { get; set; }
        public string? Comments { get; set; }
    }
}
