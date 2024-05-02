namespace BookManager.Application.InputModels
{
    public class CreateBookInputModel
    {
        public string Title { get; set; }

        public int Quantity { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public int YearPublished { get; set; }
    }
}