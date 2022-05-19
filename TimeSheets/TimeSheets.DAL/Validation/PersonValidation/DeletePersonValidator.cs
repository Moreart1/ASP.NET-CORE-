using FluentValidation;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.Services;

namespace TimeSheets.DAL.Validation.PersonValidation
{
    public interface IDeletePersonValidator : IValidationService<PersonDeleteModels>
    {

    }
    public class DeletePersonValidator:FluentValidationService<PersonDeleteModels>, IDeletePersonValidator
    {
        public DeletePersonValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithErrorCode("M05.01");
        }
    }
}
