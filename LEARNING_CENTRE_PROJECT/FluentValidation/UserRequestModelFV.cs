using FluentValidation;
using LearningCentre.Core.Domain.RequestModel;

namespace LEARNING_CENTRE_PROJECT.FluentValidation
{
    public class UserRequestModelFV:AbstractValidator<UserRequestModel>
    {
        public UserRequestModelFV()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FirstName).MaximumLength(20);
            RuleFor(x=>x.LastName).MaximumLength(20);
            RuleFor(x => x.Password).MinimumLength(4);

        }
    }
}
