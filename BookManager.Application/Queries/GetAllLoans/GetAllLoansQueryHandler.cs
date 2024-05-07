using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoanViewModel>>
    {
        private readonly ILoanRepository _repository;

        public GetAllLoansQueryHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _repository.GetAllLoanAsync();

            var loansViewModels = loans.Select(loan => new LoanViewModel(loan.Id, loan.DateLoan, loan.Status, loan.IdUser, loan.IdBook, loan.LoanDurationInDays, loan.ReturnDate)).ToList();

            return loansViewModels;
        }
    }
}