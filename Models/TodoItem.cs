using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todo_rest_api.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }

        public virtual TodoList TodoList { get; set; }

    }
}
