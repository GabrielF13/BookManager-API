using BookManager.Application.Commands.CreateLoanBook;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateLoanBookCommandValidator : AbstractValidator<CreateLoanBookCommand>
    {
        public CreateLoanBookCommandValidator()
        {
            RuleFor(l => l.LoanDurationInDays)
                .NotEmpty()
                .WithMessage("Quantidade de dias de emprestimo deve ser informado");
        }
    }
}