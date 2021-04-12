using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api;
using todo_rest_api.Dto;
using todo_rest_api.Models;
using todo_rest_api.Services;
//using todo.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private TodoListService service;

        public TodoListController(TodoListService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetTodoList(int id)
        {
            var list = service.GetById(id);
            var dto = new TodoListDto
            {
                Id = list.Id,
                Title = list.Title,
                TodoItems = list.TodoItems.Select(e => new TodoItemDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    DueDate = e.DueDate,
                    Done = e.Done

                }).ToList()

            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult PostTodoLists(TodoList list)
        {
            var todo = service.Create(list);
            return Created($"api/lists/{todo.Id}", todo);

        }

        [HttpPut("{id}")]
        public IActionResult PutTodoList(int id, [FromBody] TodoList list)
        {
            return Ok(service.Update(id, list));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoList(int id)
        {
            service.Delete(id);
            return Ok();
        }

    }
}