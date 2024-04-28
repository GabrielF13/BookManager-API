namespace BookManager.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, DateTime createdAt, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
        }

        public int Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
    }
}