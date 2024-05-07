using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.CreateLoanBook
{
    public class CreateLoanBookCommandHandler : IRequestHandler<CreateLoanBookCommand, int>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public CreateLoanBookCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateLoanBookCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(request.IdUser, request.IdBook, request.LoanDurationInDays);

            var book = await _bookRepository.GetByIdAsync(loan.Id);

            book.Borrowed();

            loan.SetExpectedReturnDate(request.LoanDurationInDays);

            await _loanRepository.SaveChangesAsync();

            return loan.Id;
        }
    }
}