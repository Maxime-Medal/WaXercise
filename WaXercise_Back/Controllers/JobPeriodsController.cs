using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaXercise.Data;
using WaXercise.Models;

namespace WaXercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPeriodsController : ControllerBase
    {
        private readonly WaXerciseContext _context;

        public JobPeriodsController(WaXerciseContext context)
        {
            _context = context;
        }

        // GET: api/JobPeriods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPeriod>>> GetJobPeriod()
        {
          if (_context.JobPeriod == null)
          {
              return NotFound();
          }
            return await _context.JobPeriod.ToListAsync();
        }

        // GET: api/JobPeriods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPeriod>> GetJobPeriod(int id)
        {
          if (_context.JobPeriod == null)
          {
              return NotFound();
          }
            var jobPeriod = await _context.JobPeriod.FindAsync(id);

            if (jobPeriod == null)
            {
                return NotFound();
            }

            return jobPeriod;
        }

        // PUT: api/JobPeriods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobPeriod(int id, JobPeriod jobPeriod)
        {
            if (id != jobPeriod.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobPeriod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPeriodExists(id))
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

        // POST: api/JobPeriods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobPeriod>> PostJobPeriod(JobPeriod jobPeriod)
        {
          if (_context.JobPeriod == null)
          {
              return Problem("Entity set 'WaXerciseContext.JobPeriod'  is null.");
          }
            _context.JobPeriod.Add(jobPeriod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobPeriod", new { id = jobPeriod.Id }, jobPeriod);
        }

        // DELETE: api/JobPeriods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPeriod(int id)
        {
            if (_context.JobPeriod == null)
            {
                return NotFound();
            }
            var jobPeriod = await _context.JobPeriod.FindAsync(id);
            if (jobPeriod == null)
            {
                return NotFound();
            }

            _context.JobPeriod.Remove(jobPeriod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobPeriodExists(int id)
        {
            return (_context.JobPeriod?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
