using System.ComponentModel.DataAnnotations;

namespace PurrBank.Entities.Contracts
{
    public interface IEntity
    {
        [Key]
        public int Id { get; }
    }
}
