namespace BookManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            Active = true;
            CreatedAt = DateTime.Now;

            Loans = new List<Loan>();
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }

        public List<Loan> Loans { get; set; }
    }
}