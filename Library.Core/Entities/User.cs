using Library.Core.Enums;

namespace Library.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
        }
        public User(string name, string email, string password, EUserRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Loans = new List<Loan>();
        }
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public EUserRole Role { get; private set; }

        public List<Loan> Loans { get; private set; }

        public bool IsAdmin()
        {
            return Role == EUserRole.Admin;
        }
    }
}
