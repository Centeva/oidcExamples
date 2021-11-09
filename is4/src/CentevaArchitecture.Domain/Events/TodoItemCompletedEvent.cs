using CentevaArchitecture.Domain.Entities;

namespace CentevaArchitecture.Domain.Events
{
    internal class TodoItemCompletedEvent : BaseDomainEvent
    {
        public TodoItem Item {get; private set;}

        public TodoItemCompletedEvent(TodoItem todoItem)
        {
            Item = todoItem;
        }
    }
}