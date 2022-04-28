using FluentValidation;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.Services;

namespace TimeSheets.DAL.Validation.UserValidation
{
    public interface IDeleteUserValidator : IValidationService<UserDeleteModel>
    {

    }
    public class DeleteUserValidator : FluentValidationService<UserDeleteModel>, IDeleteUserValidator
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithErrorCode("M15.01");
        }
    }
}
