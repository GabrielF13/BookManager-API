using BookManager.Core.Repositories;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
    {
        private readonly ILoanRepository _repository;

        public UpdateLoanCommandHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetLoanByIdAsync(request.Id);

            loan.Update(request.Status, request.LoanDurationInDays);

            loan.SetExpectedReturnDate(request.LoanDurationInDays);

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}