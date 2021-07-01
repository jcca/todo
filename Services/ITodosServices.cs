using todo.Models;
using System.Collections.Generic;

namespace todo.Services
{
    public interface ITodosServices
    {
        List<Todo> GetAll();
        Todo Get(long id);
        void Add(Todo todo);
        void Delete(long id);
        void Update(Todo todo);
    }
}