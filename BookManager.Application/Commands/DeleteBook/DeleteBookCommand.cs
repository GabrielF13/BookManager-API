using MediatR;

namespace BookManager.Application.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}