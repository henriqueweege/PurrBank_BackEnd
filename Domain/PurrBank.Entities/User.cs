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
            if (!ChangeEmail(email))
            {
                throw new ArgumentException("E-mail inválido");
            }
            
        }

        public bool ChangeEmail(string newEmail)
        {
            if (new EmailAddressAttribute().IsValid(newEmail))
            {
                Email = newEmail;
                return true;
            }
            else
            {
                return false;
            }
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
