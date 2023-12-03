using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IbaseRepository<Book> _bookRepo;
        public BookController(IbaseRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;   
            
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_bookRepo.GetByID(id));   
        }
    }
}
