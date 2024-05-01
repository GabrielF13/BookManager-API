using BookManager.Core.Enums;

namespace BookManager.Application.InputModels
{
    public class CreateLoanBookInputModel
    {
        public LoanStatusEnum Status { get;  set; }

        public int IdUser { get;  set; }

        public int IdBook { get;  set; }

        public int LoanDurationInDays { get;  set; }
    }
}