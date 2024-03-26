
namespace ClimaBrasil.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn => DateTime.Now;
    }
}