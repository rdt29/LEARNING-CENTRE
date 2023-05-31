using FluentValidation;
using LearningCentre.Core.Domain.RequestModel;

namespace LEARNING_CENTRE_PROJECT.FluentValidation
{
    public class UserUpdateReqModelFV:AbstractValidator<UserUpdateReqModel>
    {
        //public UserUpdateReqModelFV()
        //{
        //    RuleFor(x => x.Email).EmailAddress();
        //    RuleFor(x => x.FirstName).MaximumLength(20);
        //    RuleFor(x=>x.LastName).MaximumLength(20);
        //}
    }
}
