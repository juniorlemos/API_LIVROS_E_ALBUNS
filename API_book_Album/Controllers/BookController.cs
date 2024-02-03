using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API_book_Album.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IService _service;
        public BookController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

    }
}
