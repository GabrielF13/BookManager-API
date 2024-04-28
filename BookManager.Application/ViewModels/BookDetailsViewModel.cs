using BookManager.Core.Enums;

namespace BookManager.Application.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id, string title, int? idLoan, int quantity, string author, string iSBN, BookStatusEnum status, int yearPublished, DateTime createdAt)
        {
            Id = id;
            Title = title;
            IdLoan = idLoan;
            Quantity = quantity;
            Author = author;
            ISBN = iSBN;
            Status = status;
            YearPublished = yearPublished;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }

        public int? IdLoan { get; private set; }

        public int Quantity { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public int YearPublished { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}