namespace BookManager.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int iD, string fullName, string email, DateTime birthDate, DateTime createdAt, bool active)
        {
            ID = iD;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
        }

        public int ID { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
    }
}