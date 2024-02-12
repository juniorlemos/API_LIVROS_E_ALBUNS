using Businnes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        [ProducesResponseType((200), Type = typeof(List<Book>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Get()
        {
            var book = await _bookService.Get();
            return Ok(book);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Book))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
        [ProducesResponseType((200), Type = typeof(Book))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Create([FromBody] Book book)
        {
            if (!ModelState.IsValid || book == null)
            {
                return BadRequest(ModelState);
            }

            var createdBook = await _bookService.Create(book);

            if (createdBook == null)
            {
                return BadRequest(); // Ou outro código de status apropriado
            }

            return Ok(createdBook);

        }
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Book))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Update([FromBody] Book book)
        {
            if (!ModelState.IsValid || book == null)
            {
                return BadRequest(ModelState);
            }

            var updatedBook = await _bookService.Update(book);

            if (updatedBook == null)
            {
                return BadRequest();
            }

            return Ok(updatedBook);
        }
     
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Delete(long id)
        {
            await _bookService.Delete(id);
            return NoContent();
        }
    }
}
