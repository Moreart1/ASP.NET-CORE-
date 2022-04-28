using FluentValidation;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.Services;

namespace TimeSheets.DAL.Validation.EmployeeValidation
{
    public interface IDeleteEmployeeValidator : IValidationService<EmployeeDeleteModel>
    {

    }
    public class DeleteEmployeeValidator : FluentValidationService<EmployeeDeleteModel>, IDeleteEmployeeValidator
    {
        public DeleteEmployeeValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithErrorCode("M25.01");
        }
    }
}
