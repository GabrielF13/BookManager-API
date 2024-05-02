using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.CreateLoanBook
{
    public class CreateLoanBookCommandHandler : IRequestHandler<CreateLoanBookCommand, int>
    {
        private readonly BookManagerDbContext _context;

        public CreateLoanBookCommandHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLoanBookCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(request.IdUser, request.IdBook, request.LoanDurationInDays);

            var book = _context.Books.SingleOrDefault(book => book.Id == request.IdBook);

            book.Borrowed();

            loan.SetExpectedReturnDate(request.LoanDurationInDays);

            await _context.Loans.AddAsync(loan);

            await _context.SaveChangesAsync();

            return loan.Id;
        }
    }
}