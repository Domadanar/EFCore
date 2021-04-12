using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Database;
using todo_rest_api.Dto;
using todo_rest_api.Models;

namespace todo_rest_api.Services
{
    public class TodoListService
    {
        private TodoListContext _context;

        public TodoListService(TodoListContext context)
        {
            this._context = context;
        }

        public TodoList Create(TodoList list)
        {
            _context.TodoLists.Add(list);
            _context.SaveChanges();
            return list;
        }

        public TodoList GetById(int id)
        {
            var list = _context.TodoLists.Include(e => e.TodoItems).Single(td => td.Id == id);
            return list;
        }

        public TodoList Update(int id, TodoList list)
        {
            var dbList = GetById(id);
            dbList.Title = list.Title;
            _context.SaveChanges();
            return dbList;
        }

        public void Delete(int id)
        {
            var dbList = GetById(id);
            _context.TodoLists.Remove(dbList);
            _context.SaveChanges();
        }
        public IEnumerable<DashboardTodoListDto> Dashboard()
        {
            var list = _context.TodoLists.Include(e => e.TodoItems).ToList();
            var result = list.Select(e => new DashboardTodoListDto
            {
                Id = e.Id,
                Title = e.Title,
                Count = e.TodoItems.Count(t => !t.Done)
            });
            return result;
        }
    }
}