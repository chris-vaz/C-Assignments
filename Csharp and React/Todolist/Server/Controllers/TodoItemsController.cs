using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;
namespace Server.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private TodoContext _context;
        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            // Find the item in question
            var todoItem = await _context.TodoItems.FindAsync(id);
            // Check to see if we got back null, in which case return NotFound
            if (todoItem == null)
            {
                return NotFound();
            }
            // Otherwise, return the item
            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem([FromBody] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.TodoItems.Add(todoItem);
                await _context.SaveChangesAsync();
                // This uses the GetTodoItem route we wrote above
                return CreatedAtAction(
                    nameof(GetTodoItem),
                    new { id = todoItem.Id },
                    todoItem);
            }
            else
            {
                // This is what will allow us to get error messages for our front end
                return BadRequest(ModelState);
            }
        }
    }

}