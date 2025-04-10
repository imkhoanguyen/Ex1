using Ex1.Dtos;
using Ex1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bookService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("fetch/{bookId}")]
        public async Task<IActionResult> Get(int bookId)
        {
            var response = await _bookService.GetByIdAsync(bookId);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] BookCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _bookService.CreateAsync(request);

            if (response == null) return BadRequest();

            return CreatedAtAction(nameof(Get), new { bookId = response.BookId }, response);

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] BookUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _bookService.UpdateAsync(request);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteAsync(id);
            if (result == false) return BadRequest();
            return NoContent();
        }
    }
}
