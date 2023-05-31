using FluentValidation;
using LearningCentre.Core.Domain.RequestModel;

namespace LEARNING_CENTRE_PROJECT.FluentValidation
{
    public class RoleRequestModelFV:AbstractValidator<RoleRequestModel>
    {
        public RoleRequestModelFV()
        {
            RuleFor(x => x.Name).MaximumLength(20);

        }
    }
}
