using FluentValidation;
using FluentValidation.Results;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.Services;

namespace TimeSheets.DAL.Validation.UserValidation
{
    public interface ICreateUserValidator : IValidationService<User>
    {

    }
    public class CreateUserValidatior : FluentValidationService<User>, ICreateUserValidator
    {
        public CreateUserValidatior()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым")
                .WithErrorCode("M11.01");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Фамилия не должна быть пустая")
                .WithErrorCode("M12.01");

            RuleFor(x => x.Email).Custom((s, context) =>
            {
                if (!s.Contains("@"))
                {
                    context.AddFailure(new ValidationFailure(nameof(s), "Неверный Email адрес:адрес должен содержать символ @")
                    {
                        ErrorCode = "M13.01"
                    });
                }
            });

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email не должен быть пустым")
                .WithErrorCode("M13.02");

            RuleFor(x => x.Age)
                .GreaterThan(14)
                .LessThan(100)
                .WithMessage("Возраст должен быть от 14 до 100 лет")
                .WithErrorCode("M14.01");
        }
    }
}
