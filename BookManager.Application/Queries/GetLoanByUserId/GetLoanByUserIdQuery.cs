using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.GetLoanByUserId
{
    public class GetLoanByUserIdQuery : IRequest<LoanViewModel>
    {
        public GetLoanByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}