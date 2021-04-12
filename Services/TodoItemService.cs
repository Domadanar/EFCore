using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Database;
using todo_rest_api.Dto;
using todo_rest_api.Models;

namespace todo_rest_api.Services
{
    public class TodoItemService
    {
        private TodoListContext _context;
        private TodoListService _todoListService;

        public TodoItemService(TodoListContext context, TodoListService todoListService)
        {
            _context = context;
            _todoListService = todoListService;
        }
        public TodoItem Add(int listId, TodoItem item)
        {
            var todoList = _todoListService.GetById(listId);
            todoList.TodoItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public TodoItem GetById(int listId, int id)
        {
            var list = _todoListService.GetById(listId);
            var item = list.TodoItems.Single(e => e.Id == id);
            return item;
        }

        public TodoItem Update(int listId, int id, TodoItem item)
        {
            var dbItem = GetById(listId, id);
            dbItem.Title = item.Title;
            dbItem.Description = item.Description;
            dbItem.Done = item.Done;
            dbItem.DueDate = item.DueDate;
            _context.SaveChanges();
            return dbItem;
        }

        public void Delete(int listId, int id)
        {
            var dbItem = GetById(listId, id);
            _context.TodoItems.Remove(dbItem);
            _context.SaveChanges();
        }
        public int Dashboard()
        {
            var date = DateTime.Today;
            var count =_context.TodoItems.Count(e => e.DueDate.Value.Date == date);
            return count;
        }
        public List<TodoItemExtDto> CollectionToday()
        {
            var date = DateTime.Today;
            var items =_context.TodoItems.Include(e => e.TodoList).Where(e => e.DueDate.Value.Date == date).ToList();
            var result = items.Select(e => new TodoItemExtDto
            {
                ListTitle = e.TodoList.Title,
                Done = e.Done,
                Description = e.Description,
                Title = e.Title,
                DueDate = e.DueDate
            });
            return result.ToList();
        }
    }

}