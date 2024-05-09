using BookManager.Application.Commands.CreateBook;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Moq;
using System.Diagnostics.Tracing;

namespace BookManager.UnitTests.Application.Commands
{
    public class CreateBookCoomandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnBookId()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();

            var createBookCommand = new CreateBookCommand
            {
                Title = "livro tesste",
                Quantity = 10,
                Author = "gabriel fereira",
                ISBN = "sadaseas",
                YearPublished = 2024
            };

            var createBookCommandHandler = new CreateBookCommandHandler(bookRepositoryMock.Object);

            var id = await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

            Assert.True(id >= 0);

            bookRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Book>()), Times.Once);
        }
    }
}