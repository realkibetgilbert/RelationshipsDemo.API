using Microsoft.AspNetCore.Mvc;
using RelationshipsDemo.API.Core.Dtos;
using RelationshipsDemo.API.Core.Models;
using RelationshipsDemo.API.Infrastructure.Data;

namespace RelationshipsDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
           var authors= _context.Authors.ToList();
            return Ok(authors);  
        }
        [HttpPost]
        public IActionResult Post(authorToAddDto authorToAdd)
        {
            var name = authorToAdd.PublisherName;

            var trimmedName = name.Trim();

            var publisher = _context.Publishers.FirstOrDefault(c => c.Name == trimmedName);

            if (publisher != null)
            {
                var PublisherId = publisher.Id;
                //map dto to entity
                var addAuthor = new Author
                {
                    Name = authorToAdd.Name,
                    PublisherId = publisher.Id,
                };

                _context.Authors.Add(addAuthor);

                _context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute]long id)
        {
           var author= _context.Authors.Find(id);
            if (author == null) { return NotFound(); }
            return Ok(author);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(authorToAddDto authorToAdd ,[FromRoute]long id) 
        { var author=_context.Authors.Find(id);
            if (author == null) { return NotFound();}
            author.Name= authorToAdd.Name;
            author.Id= id;
            _context.Authors.Update(author);
            _context.SaveChanges();
            return Ok();
        }
    }
}
