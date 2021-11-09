using CentevaArchitecture.Domain.Enums;

namespace CentevaArchitecture.Application.TodoItems
{
    public class TodoItemSummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Reminder { get; set; }
        public PriorityLevel Priority { get; set; }
    }
}