using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentevaArchitecture.Domain.Entities;
using CentevaArchitecture.Domain.Interfaces;
using MediatR;

namespace CentevaArchitecture.Application.TodoItems
{
    public class GetTodoItemSummariesQuery : IRequest<List<TodoItemSummary>>
    {

        public class GetTodoItemSummariesHandler : IRequestHandler<GetTodoItemSummariesQuery, List<TodoItemSummary>>
        {
            private readonly IReadRepository<TodoItem> _repository;

            public GetTodoItemSummariesHandler(IReadRepository<TodoItem> repository)
            {
                _repository = repository;
            }

            public Task<List<TodoItemSummary>> Handle(GetTodoItemSummariesQuery request, CancellationToken cancellationToken)
            {
                var todos = _repository.ListAsync(new TodoItemSummarySpecification());

                return todos;
            }
        }
    }
}
