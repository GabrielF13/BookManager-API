using BookManager.Application.Queries.GetAllBooks;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Moq;

namespace BookManager.UnitTests.Application.Queries;

public class GetAllBooksCommandHandlerTests
{
    [Fact]
    public async void ThreeBooksExists_Executed_ReturnThreeBooksViewModels()
    {
        var books = new List<Book>
        {
            new Book("Titulo de teste 1", "Autor de teste 1", "Editora de teste", 2020, 10),
            new Book("Titulo de teste 2", "Autor de teste 2", "Editora de teste", 2020, 10),
            new Book("Titulo de teste 3", "Autor de teste 3", "Editora de teste", 2020, 10)
        };

        var bookRepositoryMock = new Mock<IBookRepository>();

        bookRepositoryMock.Setup(br => br.GetAll().Result).Returns(books);

        var getAllBooksQuery = new GetAllBooksQuery();

        var getAllBooksQueryHandler = new GetAllBooksQueryHandler(bookRepositoryMock.Object);


        var bookViewwModelList = await getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken());

        Assert.NotNull(bookViewwModelList);
        Assert.NotEmpty(bookViewwModelList);
        Assert.Equal(books.Count, bookViewwModelList.Count);

        bookRepositoryMock.Verify(br => br.GetAll().Result, Times.Once);
    }
}