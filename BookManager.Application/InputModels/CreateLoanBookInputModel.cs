using BookManager.Core.Enums;

namespace BookManager.Application.InputModels
{
    public class CreateLoanBookInputModel
    {
        public LoanStatusEnum Status { get; private set; }

        public int IdUser { get; private set; }

        public int IdBook { get; private set; }

        public int LoanDurationInDays { get; private set; }
    }
}