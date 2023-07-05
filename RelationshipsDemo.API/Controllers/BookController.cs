using Microsoft.AspNetCore.Mvc;
using RelationshipsDemo.API.Core.Dtos;
using RelationshipsDemo.API.Core.Models;
using RelationshipsDemo.API.Infrastructure.Data;

namespace RelationshipsDemo.API.Controllers
{
    [ApiController]
    [Route ("api/[Controller]")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _context.Books.ToList();
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute]long id)
        {
            var book = _context.Books.Find(id);
            if(book == null) { return NotFound(); }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post(bookToAddDto bookToAdd)
        {
            var name = bookToAdd.AuthorName;
            var trimmedName = name.Trim();
            var author = _context.Authors.FirstOrDefault(c => c.Name == trimmedName);
            if (author == null) { return BadRequest();}
            var AuthorId=author.Id;
            //map dto to entity
            var addBook = new Book
            {
                Title = bookToAdd.Title,
                AuthorId = author.Id,
            };
            _context.Books.Add(addBook);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put (bookToAddDto bookToAdd, [FromRoute] long id)
        {
            var book = _context.Books.Find(id);
            if (book == null) { return NotFound();}
           book.Title= bookToAdd.Title;
            book.Id= id;    
            _context.Books.Update(book);
            _context.SaveChanges();
            return Ok();

        }
    }
}
