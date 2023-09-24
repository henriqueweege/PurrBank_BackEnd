using System.ComponentModel.DataAnnotations;

namespace Bank.Entities.Contracts
{
    public interface IEntity
    {
        [Key]
        public int Id { get; }
    }
}
