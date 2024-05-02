using BookManager.Core.Enums;
using MediatR;

namespace BookManager.Application.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Quantity { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public BookStatusEnum Status { get; set; }

        public int YearPublished { get; set; }
    }
}