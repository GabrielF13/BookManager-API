using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<LoanViewModel>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}