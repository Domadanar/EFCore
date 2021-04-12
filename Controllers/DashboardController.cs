using System.Linq;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Dto;
using todo_rest_api.Services;

namespace todo_rest_api.Controllers
{
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private TodoItemService _todoItemService;

        private TodoListService _todoListService;

        public DashboardController(TodoItemService todoItemService, TodoListService todoListService)
        {
            _todoItemService = todoItemService;
            _todoListService = todoListService;
        }
        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            var dto = new DashboardDto
            {
                Count = _todoItemService.Dashboard(),
                TodoLists = _todoListService.Dashboard().ToList()
            };
            return Ok(dto);
        }
        [HttpGet("collection/today")]

        public IActionResult GetCollectionToday()
        {
         var list = _todoItemService.CollectionToday();
          return Ok(list);
        }
    }
}

