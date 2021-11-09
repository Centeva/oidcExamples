using MediatR;

namespace CentevaArchitecture.Domain
{
    public class BaseDomainEvent : INotification
    {
        public DateTimeOffset Occurred { get; protected set; } = DateTimeOffset.UtcNow;
    }
}