using Microsoft.AspNetCore.Mvc;
using RelationshipsDemo.API.Core.Dtos;
using RelationshipsDemo.API.Core.Models;
using RelationshipsDemo.API.Infrastructure.Data;

namespace RelationshipsDemo.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PublisherController : Controller
    {
        private readonly AppDbContext _context;

        public PublisherController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _context.Publishers.ToList();

            return Ok();
        }
        [HttpPost]
        public IActionResult Post(publisherToAddDto publisherToAdd)
        {
            var addPublisher = new Publisher
            {
                Name = publisherToAdd.Name,
            };
            _context.Publishers.Add(addPublisher);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(publisherToAddDto publisherToAdd, [FromRoute] long id)
        {
            var publisher = _context.Publishers.Find(id);
            if (publisher == null) { return NotFound(); }
            publisher.Name = publisherToAdd.Name;
            publisher.Id = id;
            _context.Publishers.Update(publisher);
            _context.SaveChanges();
            return Ok();
        }
    }
}
