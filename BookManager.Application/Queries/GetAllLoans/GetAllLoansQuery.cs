using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<List<LoanViewModel>>
    {
    }
}