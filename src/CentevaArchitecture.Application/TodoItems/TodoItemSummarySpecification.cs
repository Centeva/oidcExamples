using Ardalis.Specification;
using CentevaArchitecture.Domain.Entities;

namespace CentevaArchitecture.Application.TodoItems
{
    public class TodoItemSummarySpecification : Specification<TodoItem, TodoItemSummary>
    {
        public TodoItemSummarySpecification()
        {
            Query
                .Select(x => new TodoItemSummary
                {
                    Id = x.Id,
                    Title = x.Title,
                    Reminder = x.Reminder,  
                    Priority = x.Priority
                })
                .OrderBy(x => x.CreatedAt);
        }
    }
}
