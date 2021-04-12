using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Dto;
using todo_rest_api.Models;
using todo_rest_api.Services;

namespace todo_rest_api.Controllers
{
    [Route("api/lists/{listId}/items")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoItemService _todoItemService;

        public TodoItemController(TodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpPost]
        public IActionResult PostTodoItems(int listId, [FromBody] TodoItem item)
        {
            var todo = _todoItemService.Add(listId, item);
            var dto = new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                DueDate = todo.DueDate,
                Done = todo.Done
            };
            return Created($"api/lists/{listId}/items/{todo.Id}", dto);
        }

        [HttpPut("{id}")]
        public IActionResult PutTodoItems(int listId, int id, [FromBody] TodoItem item)
        {
            var todo = _todoItemService.Update(listId, id, item);
            var dto = new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                DueDate = todo.DueDate,
                Done = todo.Done
            };
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItems(int listId, int id)
        {
            _todoItemService.Delete(listId, id);
            return Ok();
        }

    }
}