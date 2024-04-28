using BookManager.Core.Enums;

namespace BookManager.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, DateTime dateLoan, LoanStatusEnum status, int idUser, int idBook, int loanDurationInDays, DateTime returnDate)
        {
            Id = id;
            DateLoan = dateLoan;
            Status = status;
            IdUser = idUser;
            IdBook = idBook;
            LoanDurationInDays = loanDurationInDays;
            ReturnDate = returnDate;
        }

        public int Id { get; private set; }
        public DateTime DateLoan { get; private set; }
        public LoanStatusEnum Status { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public int LoanDurationInDays { get; private set; }
        public DateTime ReturnDate { get; set; }
    }
}