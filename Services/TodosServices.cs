using todo.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todo.Contexts;
using System;

namespace todo.Services
{
    public class TodosService : ITodosServices
    {
        private readonly TodoContext _context;

        public TodosService(TodoContext context)
        {
            _context = context;
        }

        public List<Todo> GetAll() =>  _context.Todos.ToList();

        public Todo Get(long id) => _context.Todos.FirstOrDefault(t => t.Id == id);

        public void Add(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.Todos.FirstOrDefault(t => t.Id == id);  
            _context.Todos.Remove(entity);  
            _context.SaveChanges(); 
        }

        public void Update(Todo todo)
        { 
            _context.Todos.Update(todo);  
            _context.SaveChanges(); 
        }
    }
}