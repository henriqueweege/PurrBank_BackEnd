using PurrBank.Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PurrBank.Entities
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public User(string firstName, string lastName, string email)
        {
            ChangeFirstName(firstName);
            ChangeLastName(lastName);
            ChangeEmail(email);
        }

        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void ChangeFirstName(string newFirstName)
        {
            FirstName = newFirstName;
        }

        public void ChangeLastName(string newLastName)
        {
            LastName = newLastName;
        }
    }
}
