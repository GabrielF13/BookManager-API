using BookManager.Core.Enums;

namespace BookManager.Application.InputModels
{
    public class UpdateBookInputModel
    {
        public string Title { get; set; }

        public int Quantity { get; set; }

        public string Author { get; set; }

        public string ISBN { get;  set; }

        public BookStatusEnum Status { get;  set; }

        public int YearPublished { get;  set; }
    }
}