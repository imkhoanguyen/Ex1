using Ex1.Dtos;
using Ex1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IBookService _bookService;
        public ReportsController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("book")]
        public async Task<IActionResult> GetBookWithFilter([FromQuery] BookFilterRequest request)
        {
            var response = await _bookService.GetFilterBooks(request);

            return Ok(response);
        }
    }
}
