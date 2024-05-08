using BookManager.Application.Commands.CreateBook;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .MaximumLength(100)
                .WithMessage("Título deve conter no maximo 100 caracteres");

            RuleFor(b => b.Author)
                .MaximumLength(150)
                .WithMessage("Autor deve conter no maximo 150 caracteres");

            RuleFor(b => b.ISBN)
                .NotNull()
                .WithMessage("ISBN deve ser informado");
        }
    }
}