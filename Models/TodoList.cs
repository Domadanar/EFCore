using System.Collections.Generic;

namespace todo_rest_api.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<TodoItem> TodoItems { get; set; }
    }
}