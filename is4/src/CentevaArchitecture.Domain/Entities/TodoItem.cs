using CentevaArchitecture.Domain.Enums;
using CentevaArchitecture.Domain.Events;
using CentevaArchitecture.Domain.Interfaces;

namespace CentevaArchitecture.Domain.Entities
{
    public class TodoItem : BaseEntity, IAggregateRoot, ITimestamped
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? Reminder { get; set; }
        public PriorityLevel Priority { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (!_done)
                {
                    DomainEvents.Add(new TodoItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? LastUpdatedAt { get; set; }
    }
}
