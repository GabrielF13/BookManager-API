namespace BookManager.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, int idBook, int idLoan, string author, string iSBN, int yearPublished)
        {
            Title = title;
            IdBook = idBook;
            IdLoan = idLoan;
            Author = author;
            ISBN = iSBN;
            YearPublished = yearPublished;

            Loans = new List<Loan>();
        }

        public string Title { get; private set; }

        public int IdBook { get; private set; }

        public int IdLoan { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public int YearPublished { get; private set; }

        public List<Loan> Loans { get; private set; }
    }
}