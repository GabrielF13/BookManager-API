using MediatR;

namespace BookManager.Application.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }

        public int Quantity { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public int YearPublished { get; set; }
    }
}