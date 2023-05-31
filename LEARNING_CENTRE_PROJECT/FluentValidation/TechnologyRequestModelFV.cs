using FluentValidation;
using LearningCentre.Core.Domain.RequestModel;

namespace LEARNING_CENTRE_PROJECT.FluentValidation
{
    public class TechnologyRequestModelFV:AbstractValidator<TechnologyRequestModel>
    {
        public TechnologyRequestModelFV()
        {
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Name must be not more than 20 characters.");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Description must be not more than 50 characters.");
        }
    }
}
