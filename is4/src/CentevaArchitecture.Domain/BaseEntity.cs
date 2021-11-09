namespace CentevaArchitecture.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> DomainEvents = new List<BaseDomainEvent>();
    }
}
