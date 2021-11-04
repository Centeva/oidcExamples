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
    public class CreateTodoItemCommand : IRequest<int>
    {
        public string Title { get; set; }

        public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, int>
        {
            private readonly IRepository<TodoItem> _repository;

            public CreateTodoItemHandler(IRepository<TodoItem> repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
            {
                var todo = new TodoItem
                {
                    Title = request.Title
                };

                await _repository.AddAsync(todo, cancellationToken);

                return todo.Id;
            }
        }
    }
}
