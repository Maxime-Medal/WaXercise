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
    public class CompagnyController : ControllerBase
    {
        private readonly WaXerciseContext _context;

        public CompagnyController(WaXerciseContext context)
        {
            _context = context;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compagny>>> GetWork()
        {
          if (_context.Compagny == null)
          {
              return NotFound();
          }
            return await _context.Compagny.ToListAsync();
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compagny>> GetWork(int id)
        {
          if (_context.Compagny == null)
          {
              return NotFound();
          }
            var work = await _context.Compagny.FindAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(int id, Compagny compagny)
        {
            if (id != compagny.Id)
            {
                return BadRequest();
            }

            _context.Entry(compagny).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
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

        // POST: api/Works
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<Compagny>> PostWork(int id, Compagny compagny)
        {
          if (_context.Compagny == null)
          {
              return Problem("Entity set 'WaXerciseContext.Work'  is null.");
          }
            compagny.PeopleId = id;

            _context.Compagny.Add(compagny);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWork", new { id = compagny.Id }, compagny);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            if (_context.Compagny == null)
            {
                return NotFound();
            }
            var work = await _context.Compagny.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            _context.Compagny.Remove(work);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkExists(int id)
        {
            return (_context.Compagny?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
