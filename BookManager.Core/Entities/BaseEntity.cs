namespace BookManager.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }

        public int Id { get; private set; }
    }
}