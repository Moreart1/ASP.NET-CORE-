using FluentValidation;
using FluentValidation.Results;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.Services;

namespace TimeSheets.DAL.Validation.EmployeeValidation
{
    public interface ICreateEmployeeValidator : IValidationService<Employee>
    {

    }
    public class CreateEmployeeValidatior : FluentValidationService<Employee>, ICreateEmployeeValidator
    {
        public CreateEmployeeValidatior()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым")
                .WithErrorCode("M21.01");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Фамилия не должна быть пустая")
                .WithErrorCode("M22.01");

            RuleFor(x => x.Email).Custom((s, context) =>
            {
                if (!s.Contains("@"))
                {
                    context.AddFailure(new ValidationFailure(nameof(s), "Неверный Email адрес:адрес должен содержать символ @")
                    {
                        ErrorCode = "M23.01"
                    });
                }
            });

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email не должен быть пустым")
                .WithErrorCode("M23.02");

            RuleFor(x => x.Age)
                .GreaterThan(14)
                .LessThan(100)
                .WithMessage("Возраст должен быть от 14 до 100 лет")
                .WithErrorCode("M24.01");
        }
    }
}
