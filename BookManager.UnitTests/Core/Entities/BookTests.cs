using BookManager.Core.Entities;
using BookManager.Core.Enums;

namespace BookManager.UnitTests.Core.Entities
{
    public class BookTests
    {
        [Fact]
        public void TestIfBooksBorrowedWorks()
        {
            var book = new Book("Titulo de teste", "Autor de teste", "Editora de teste", 2020, 10);

            Assert.NotEmpty(book.Title);
            Assert.NotNull(book.Title);

            book.Borrowed();

            Assert.Equal(BookStatusEnum.Available, book.Status);
            Assert.Equal(9, book.Quantity);
        }

        [Fact]
        public void TestIfBooksReturnedWorks()
        {
            var book = new Book("Titulo de teste", "Autor de teste", "Editora de teste", 2020, 10);

            Assert.NotEmpty(book.Title);
            Assert.NotNull(book.Title);

            book.Returned();

            Assert.Equal(BookStatusEnum.Available, book.Status);
            Assert.Equal(11, book.Quantity);
        }
    }
}