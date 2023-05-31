using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Builder
{
    public class TaskEvaluationBuilder
    {
        public static TaskEvaluation Build(TaskEvaluationRequestModel request)
        {
            return new TaskEvaluation()
            {
                SubmittedTaskId = request.SubmittedTaskId,
                //UserId = request.UserId,
                Communication = request.Communication,
                Discipline = request.Discipline,
                CodingConvention = request.Discipline,
                TechnicalSkill = request.TechnicalSkill,
                FeedBack = request.FeedBack,
                LearningAdaptability = request.LearningAdaptability,
            };
        }
    }
}