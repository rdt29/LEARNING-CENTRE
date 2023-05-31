using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Domain.Entities
{
    public class TaskEvaluation : Audit
    {
        public TaskEvaluation()
        {
            FeedBack = "string";
            TechnicalSkill = 0;
            Discipline = 0;
            Communication = 0;
            LearningAdaptability = 0;
            CodingConvention = 0;
            SubmittedTaskId = 0;
            UserId = 0;
        }

        [Key]
        public int Id { get; set; }

        public int SubmittedTaskId { get; set; }
        //public int TaskEvaluationId { get; set; }

        public int UserId { get; set; }
        public int Communication { get; set; }
        public int LearningAdaptability { get; set; }
        public int Discipline { get; set; }
        public int TechnicalSkill { get; set; }
        public int CodingConvention { get; set; }

        public string FeedBack { get; set; }

        [ForeignKey(nameof(SubmittedTaskId))]
        public SubmittedTasks SubmittedTask { get; set; }

        public TaskEvaluation DeleteTaskEvaluation()
        {
            IsDeleted = true;
            return this;
        }

        public TaskEvaluation UpdateTaskEvaluation(int assignTaskId, int codingConvention, int discipline, int communication, int learningAdaptability, string feedBack)
        {
            SubmittedTaskId = assignTaskId;
            CodingConvention = codingConvention;
            Discipline = discipline;
            Communication = communication;
            LearningAdaptability = learningAdaptability;
            FeedBack = feedBack;
            return this;
        }
    }
}