using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
    {
        private readonly BookManagerDbContext _context;

        public UpdateLoanCommandHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = _context.Loans.SingleOrDefault(loan => loan.Id == request.Id);

            loan.Update(request.Status, request.LoanDurationInDays);

            loan.SetExpectedReturnDate(request.LoanDurationInDays);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}