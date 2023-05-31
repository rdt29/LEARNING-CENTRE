using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class TaskEvaluationResponseModel
    {
        public int Id { get; set; } 
        public int AssignTaskId { get; set; }
     
        public int UserId { get; set; }
        public int Communication { get; set; }
        public int LearningAdaptability { get; set; }
        public int Discipline { get; set; }
        public int TechnicalSkill { get; set; }
        public int CodingConvention { get; set; }

        public string FeedBack { get; set; }
    }
}
