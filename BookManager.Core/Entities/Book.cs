using BookManager.Core.Enums;

namespace BookManager.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, int yearPublished, int quantity)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublished = yearPublished;
            Quantity = quantity;
            CreatedAt = DateTime.Now;

            Status = BookStatusEnum.Available;
            Loans = new List<Loan>();
        }

        public string Title { get; private set; }

        public int? IdLoan { get; private set; }

        public int Quantity { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public int YearPublished { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public List<Loan> Loans { get; private set; }

        public void Cancel()
        {
            if (Status == BookStatusEnum.Available)
            {
                Status = BookStatusEnum.Unavailable;
            }
        }

        public void Borrowed()
        {
            if (Status == BookStatusEnum.Available && Quantity > 0)
            {
                Quantity -= 1;
            }
            else if (Status == BookStatusEnum.Available)
            {
                Status = BookStatusEnum.Borrowed;
            }
        }

        public void Update(string title, int quantity, string author, string iSBN, BookStatusEnum status, int yearPublished)
        {
            Title = title;
            Quantity = quantity;
            Author = author;
            ISBN = iSBN;
            Status = status;
            YearPublished = yearPublished;
        }

        public void Returned()
        {
            if (Status == BookStatusEnum.Borrowed)
            {
                Quantity += 1;
                Status = BookStatusEnum.Available;
            }
            else
            {
                Quantity += 1;
            }
        }
    }
}