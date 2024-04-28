namespace BookManager.Application.InputModels
{
    public class NewBookInputModel
    {
        public string Title { get; private set; }

        public int IdBook { get; private set; }

        public int IdLoan { get; private set; }

        public int Quantity { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public int YearPublished { get; private set; }
    }
}