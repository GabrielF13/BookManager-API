using BookManager.Application.Commands.CreateBook;
using BookManager.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BookManager.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email is not valid");

            RuleFor(p => p.Password)
                    .Must(ValidaPassword)
                    .WithMessage("Senha deve conter pelo menos 8 caracteres, um numero, uma letra maiuscula, uma letra minuscula e um caractere especial");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatorio");
        }

        public bool ValidaPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}