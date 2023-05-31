using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.RequestModel
{
    public class TaskEvaluationRequestModel
    {
        // public int UserId { get; set; }
        public int SubmittedTaskId { get; set; }

        public int Communication { get; set; }
        public int LearningAdaptability { get; set; }
        public int Discipline { get; set; }
        public int TechnicalSkill { get; set; }
        public int CodingConvention { get; set; }
        public string FeedBack { get; set; }
    }
}