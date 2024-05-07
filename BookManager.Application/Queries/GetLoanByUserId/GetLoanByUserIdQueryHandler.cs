using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetLoanByUserId
{
    public class GetLoanByUserIdQueryHandler : IRequestHandler<GetLoanByUserIdQuery, LoanViewModel>
    {
        private readonly ILoanRepository _repository;

        public GetLoanByUserIdQueryHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoanViewModel> Handle(GetLoanByUserIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetLoanByUserIdAsync(request.UserId);

            var loanViewModel = new LoanViewModel(loan.Id, loan.DateLoan, loan.Status, loan.IdUser, loan.IdBook, loan.LoanDurationInDays, loan.ReturnDate);

            return loanViewModel;
        }
    }
}