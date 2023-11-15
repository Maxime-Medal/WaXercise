using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaXercise.Data;
using WaXercise.Models;
using WaXercise.Services.Interfaces;

namespace WaXercise.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly WaXerciseContext _context;
        private readonly IPeopleService _peopleService;

        public PeopleController(
            WaXerciseContext context,
            IPeopleService peopleService)
        {
            _context = context;
            _peopleService = peopleService;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetPeople()
        {
          if (_context.People == null)
          {
              return NotFound();
          }
            return await _context.People.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeople(int id)
        {
          if (_context.People == null)
          {
              return NotFound();
          }
            var people = await _context.People.FindAsync(id);

            if (people == null)
            {
                return NotFound();
            }

            return people;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeople(int id, People people)
        {
            if (id != people.Id)
            {
                return BadRequest();
            }

            var isValid = _peopleService.IsAgeIsValid(people.BirthDate, 100);

            if (!isValid)
            {
                return BadRequest("l'age doit être inferieur à 100 ans");
            }
            _context.Entry(people).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<People>> PostPeople(People people)
        {
          if (_context.People == null)
          {
              return Problem("Entity set 'WaXerciseContext.People'  is null.");
          }

            var isValid = _peopleService.IsAgeIsValid(people.BirthDate, 100);

            if (!isValid)
            {
                return BadRequest("l'age doit être inferieur à 100 ans");
            }

            _context.People.Add(people);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = people.Id }, people);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            if (_context.People == null)
            {
                return NotFound();
            }
            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            _context.People.Remove(people);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeopleExists(int id)
        {
            return (_context.People?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
