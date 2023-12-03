using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IbaseRepository<Author> _authorRepo;
        public AuthorsController(IbaseRepository<Author> authorRepo)
        {
            _authorRepo = authorRepo;   
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            return Ok(_authorRepo.GetByID(id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_authorRepo.GetAll());
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetbyName(string name)
        {
            return Ok(_authorRepo.Find(b=> b.Name == name));    
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody]Author author)
        {
            var id  = _authorRepo.Add(author);
            
            return CreatedAtAction(nameof(GetById), new {id = id, Controller = "Authors"}, id);
            
        }
    }
}
