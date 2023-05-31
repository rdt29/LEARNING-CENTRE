using FluentValidation;
using LearningCentre.Core.Domain.RequestModel;

namespace LEARNING_CENTRE_PROJECT.FluentValidation
{
    public class TaskEvaluationRequestModelFV:AbstractValidator<TaskEvaluationRequestModel>
    {
        public TaskEvaluationRequestModelFV()
        {
            RuleFor(x => x.FeedBack).MaximumLength(50).WithMessage("FeedBack must be not more than 50 characters.");
            RuleFor(x => x.Discipline).InclusiveBetween(0, 10);
            RuleFor(x=>x.LearningAdaptability).InclusiveBetween(0, 10);
            RuleFor(x=>x.CodingConvention).InclusiveBetween(0, 10);
            RuleFor(x=>x.Communication).InclusiveBetween(0, 10);
            RuleFor(x=>x.TechnicalSkill).InclusiveBetween(0, 10);
           
        }
    }
}
