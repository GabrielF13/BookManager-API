using BookManager.Core.Enums;

namespace BookManager.Application.InputModels
{
    public class UpdateLoanInputModel
    {
        public LoanStatusEnum Status { get; set; }

        public int LoanDurationInDays { get; set; }
    }
}