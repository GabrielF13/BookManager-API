using BookManager.Core.Enums;
using MediatR;

namespace BookManager.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public LoanStatusEnum Status { get; set; }

        public int LoanDurationInDays { get; set; }
    }
}