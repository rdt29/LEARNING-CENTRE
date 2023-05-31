using FluentValidation;
using LearningCentre.Core.Domain.RequestModel;

namespace LEARNING_CENTRE_PROJECT.FluentValidation
{
    public class UserLoginReqModelFV:AbstractValidator<UserLoginReqModel>
    {
        public UserLoginReqModelFV()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(4);
        }
    }
}
