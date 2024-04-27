namespace BookManager.Core.Entities
{
    public class UserBooks : BaseEntity
    {
        public UserBooks(int idUser, int idBook)
        {
            IdUser = idUser;
            IdBook = idBook;
        }

        public int IdUser { get; private set; }
        public int IdBook { get; private set; }

        public Book Books { get; private set; }
    }
}
