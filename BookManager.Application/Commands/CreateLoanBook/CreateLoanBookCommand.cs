using BookManager.Core.Enums;
using MediatR;

namespace BookManager.Application.Commands.CreateLoanBook
{
    public class CreateLoanBookCommand : IRequest<int>
    {
        public LoanStatusEnum Status { get; set; }

        public int IdUser { get; set; }

        public int IdBook { get; set; }

        public int LoanDurationInDays { get; set; }
    }
}