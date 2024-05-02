using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly BookManagerDbContext _context;

        public DeleteLoanCommandHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(loan => loan.Id == request.Id);

            _context.Loans.Remove(loan);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}