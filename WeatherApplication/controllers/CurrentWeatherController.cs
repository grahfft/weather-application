using Microsoft.AspNetCore.Mvc;

[Route("/Weather/Current")]
[ApiController]
public class CurrentWeatherController : ControllerBase
{
    // [HttpGet("{zipcode}")]
    // public async Task<ActionResult<>> GetTodoItem(long id)
    // {
    //     var todoItem = await _context.TodoItems.FindAsync(id);

    //     if (todoItem == null)
    //     {
    //         return NotFound();
    //     }

    //     return todoItem;
    // }
}