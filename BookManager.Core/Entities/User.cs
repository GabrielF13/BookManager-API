namespace BookManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;

            Active = true;
            CreatedAt = DateTime.Now;

            Loans = new List<Loan>();
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public List<Loan> Loans { get; set; }
    }
}