using System.Collections.Generic;

namespace todo_rest_api.Dto
{
    public class TodoListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  List<TodoItemDto> TodoItems { get; set; }
    }
}