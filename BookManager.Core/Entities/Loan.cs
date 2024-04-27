using BookManager.Core.Enums;

namespace BookManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(LoanStatusEnum status, int idUser, int idBook, DateTime returnDate, int loanDurationInDays)
        {
            Status = status;
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;
            LoanDurationInDays = loanDurationInDays;

            DateLoan = DateTime.Now;
        }

        public LoanStatusEnum Status { get; private set; }

        public int IdUser { get; private set; }

        public int IdBook { get; private set; }

        public int LoanDurationInDays { get; private set; }

        public DateTime ReturnDate { get; set; }

        public DateTime DateLoan { get; private set; }

    }
}