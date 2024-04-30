using BookManager.Core.Enums;

namespace BookManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook, int loanDurationInDays)
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDurationInDays = loanDurationInDays;

            Status = LoanStatusEnum.Approved;
            DateLoan = DateTime.Now;
            Books = new List<Book>();
        }

        public LoanStatusEnum Status { get; private set; }

        public User User { get; private set; }

        public int IdUser { get; private set; }

        public Book Book { get; private set; }

        public int IdBook { get; private set; }

        public int LoanDurationInDays { get; private set; }

        public DateTime ReturnDate { get; set; }

        public DateTime DateLoan { get; private set; }

        public List<Book> Books { get; private set; }

        public void SetExpectedReturnDate(int loanDurationInDays)
        {
            ReturnDate = DateTime.Now.AddDays(loanDurationInDays);
        }

        public void Update(LoanStatusEnum status, int loanDurationInDays )
        {
            Status = status;
            LoanDurationInDays = loanDurationInDays;
        }
    }
}