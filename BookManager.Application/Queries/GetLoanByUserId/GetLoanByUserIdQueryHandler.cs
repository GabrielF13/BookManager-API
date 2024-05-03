using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application.Queries.GetLoanByUserId
{
    public class GetLoanByUserIdQueryHandler : IRequestHandler<GetLoanByUserIdQuery, LoanViewModel>
    {
        private readonly BookManagerDbContext _context;

        public GetLoanByUserIdQueryHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<LoanViewModel> Handle(GetLoanByUserIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(loan => loan.Id == request.UserId);

            var loanViewModel = new LoanViewModel(loan.Id, loan.DateLoan, loan.Status, loan.IdUser, loan.IdBook, loan.LoanDurationInDays, loan.ReturnDate);

            return loanViewModel;
        }
    }
}