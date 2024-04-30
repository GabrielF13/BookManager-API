using BookManager.Core.Enums;

namespace BookManager.Application.InputModels
{
    public class UpdateLoanInputModel
    {
        public int Id { get; private set; }

        public LoanStatusEnum Status { get; private set; }

        public int LoanDurationInDays { get; private set; }
    }
}