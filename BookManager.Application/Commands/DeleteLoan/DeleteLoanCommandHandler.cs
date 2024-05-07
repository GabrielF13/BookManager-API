using BookManager.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly ILoanRepository _repository;

        public DeleteLoanCommandHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetLoanByIdAsync(request.Id);

            await _repository.DeleteLoanAsync(loan);

            return Unit.Value;
        }
    }
}