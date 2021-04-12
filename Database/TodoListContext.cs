using System;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Models;

namespace todo_rest_api.Database
{
    public class TodoListContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .UseSnakeCaseNamingConvention()
                .UseNpgsql("Host=127.0.0.1;Username=entity_app;Password=1234;Database=entity");
        }

        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {

        }
    }
}