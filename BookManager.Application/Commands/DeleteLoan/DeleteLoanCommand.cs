using MediatR;

namespace BookManager.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteLoanCommand(int id)
        {
            Id = id;
        }
    }
}