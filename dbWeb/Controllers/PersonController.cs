using dbWeb.Data;
using dbWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dbWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly DatabaseAPIContext _context;
        //private Crud<Person> _crudPerson = new Crud<Person>();

        public PersonController(DatabaseAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Persons.ToListAsync());
            //return await _crudPerson.Get();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person != null)
            {
                return Ok(person);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Insert([Bind("FirstMidName,LastName")] Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, Person person)
        {
            var dbPerson = await _context.Persons.FindAsync(id);

            if (dbPerson != null)
            {
                dbPerson.LastName = person.LastName;
                dbPerson.FirstMidName = person.FirstMidName;

                await _context.SaveChangesAsync();

                return Ok(person);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person != null)
            {
                _context.Remove(person);
                await _context.SaveChangesAsync();
                return Ok(person);
            }

            return NotFound();
        }
    }
}
