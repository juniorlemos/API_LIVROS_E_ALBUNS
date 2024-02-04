using Businnes;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API_book_Album.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBasicService<Book> _bookService;
        public BookController(IBasicService<Book> bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var book = await _bookService.Get();
            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetId(long id)
        {
            var book = await _bookService.GetId(id);
            if (book == null)
            { 
            return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
             
            var bookEntity = await _bookService.Create(book);

            return Ok(bookEntity);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            var bookEntity = await _bookService.Update(book);

            return Ok(bookEntity);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _bookService.Delete(id);
            return NoContent();
        }
    }
}
