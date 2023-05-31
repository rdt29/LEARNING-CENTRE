using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class SubmittedTaskResponseModel
    {
     
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int AssignTaskId { get; set; }

        public string Status { get; set; }

        public string? DocumentURL { get; set; }
        public DateTimeOffset Submission { get; set; }
        public string Comments { get; set; }
    }
}
