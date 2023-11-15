using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaXercise.Data;
using WaXercise.Models;
using WaXercise.Models.DTO;
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
        public async Task<ActionResult<IEnumerable<PeopleDTO>>> GetPeople()
        {
            if (_context.People == null)
            {
                return NotFound();
            }

            var peoples = await _context.People
                .Include(p => p.Compagnies)
                //.Include(p => p.JobsPeriods)
                .OrderBy(p => p.BirthDate)
                .ToListAsync();

            List<PeopleDTO> peoplesDTO = new();

            foreach (var people in peoples)

            peoplesDTO.Add(new PeopleDTO()
            {
                FirstName = people.FirstName,
                LastName = people.LastName,
                Age = _peopleService.GetAge(people.BirthDate),
                Compagnies = people.Compagnies

            });

            return peoplesDTO;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeopleDTO>> GetPeople(int id)
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

            var newPeople = new PeopleDTO()
            {
                FirstName = people.FirstName,
                LastName = people.LastName,
                Age = _peopleService.GetAge(people.BirthDate),
                Compagnies = people.Compagnies
            };

            return newPeople;
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

            //var lastCompagny = _context.Compagny.OrderBy(c => c.Id).FirstOrDefault();
            //int lastId = lastCompagny != null ? lastCompagny.Id : 0;

            List<Compagny> newCompagnies = new();
            foreach (var comp in people.Compagnies)
            {
                //lastId ++;
                newCompagnies.Add(new Compagny()
                {
                    Label = comp.Label,
                    StartDate = comp.StartDate,
                    EndDate = comp.EndDate,
                });
            }

            var newPeople = new People()
            {
                FirstName = people.FirstName,
                LastName = people.LastName,
                BirthDate = people.BirthDate,
                Compagnies = newCompagnies
            };


            //var newWorkLabels = people.Compagnies.Select(x => x.Label).ToList();
            //var compagnies = _context.Compagny.ToList();

            //foreach (var label in newWorkLabels) {
            //    foreach (var job in compagnies) { 
            //        if(job.Label == label)
            //        {
            //            //newPeople.Compagnies.Where(w => w.Id == job.Id).Select(w =>
            //            //{
            //            //}) = job.Id;

            //        }
            //    }


            //= _context.Compagny.where

            //List<Compagny>? newWorks = people.Compagnies;
            //List<JobPeriod>? newJobs = people.JobsPeriods;

            //var IsWork;
            //List<Compagny> works = _context.Compagny.ToList();
            //var workIds = newPeople.Works.ForEach(nw => ); 

            _context.People.Add(newPeople);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new
            {
                id = newPeople.Id
            }, newPeople);
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<People>> PostPeopleBis(People people)
        //{
        //  if (_context.People == null)
        //  {
        //      return Problem("Entity set 'WaXerciseContext.People'  is null.");
        //  }

        //    var isValid = _peopleService.IsAgeIsValid(people.BirthDate, 100);

        //    if (!isValid)
        //    {
        //        return BadRequest("l'age doit être inferieur à 100 ans");
        //    }

        //    _context.People.Add(people);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPeople", new { id = people.Id }, people);
        //}

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
