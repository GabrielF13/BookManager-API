using BookManager.Core.Enums;

namespace BookManager.Application.InputModels
{
    public class UpdateBookInputModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public int Quantity { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public int YearPublished { get; private set; }
    }
}