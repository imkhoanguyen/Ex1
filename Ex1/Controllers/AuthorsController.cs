using Ex1.Dtos;
using Ex1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _authorService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("fetch/{authorId}")]
        public async Task<IActionResult> Get(int authorId)
        {
            var response = await _authorService.GetByIdAsync(authorId);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] AuthorCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _authorService.CreateAsync(request);

            if(response == null) return BadRequest();

            return CreatedAtAction(nameof(Get), new { authorId = response.AuthorId }, response);
            
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] AuthorUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _authorService.UpdateAsync(request);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _authorService.DeleteAsync(id);
            if (result == false) return BadRequest(); 
            return NoContent();
        }
    }
}
