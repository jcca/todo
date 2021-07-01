using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todo.Models;
using todo.Services;

namespace todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private readonly ITodosServices _services;

        public TodosController(ILogger<TodosController> logger, ITodosServices services)
        {
            _logger = logger;
            _services = services;
        }
        // GET all action
        [HttpGet]
        public ActionResult<List<Todo>> GetAll() => _services.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Todo> Get(long id) => _services.Get(id);

        // POST action
        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _services.Add(todo);
            return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(long id, Todo todo)
        {
            if (id != todo.Id)
                return BadRequest();

            _services.Update(todo);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _services.Delete(id);
            return NoContent();
        }
    }
}
