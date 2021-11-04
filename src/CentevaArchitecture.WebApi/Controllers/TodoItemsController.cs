using CentevaArchitecture.Application.TodoItems;
using Microsoft.AspNetCore.Mvc;

namespace CentevaArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetTodoItemSummariesQuery()));
        }

        [HttpGet("{id}", Name = "GetTodoItem")]
        public IActionResult GetSingle(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateTodoItemCommand command)
        {
            // Probably should return a 201 Created and the URI of the todo
            var newId = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetSingle), new { id = newId }, null);
        }
    }
}