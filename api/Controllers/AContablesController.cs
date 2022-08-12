using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AContablesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public AContablesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/AContables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asientos_Contables>>> GetAsientos_Contables()
        {
            return await _context.Asientos_Contables.ToListAsync();
        }

        // GET: api/AContables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asientos_Contables>> GetAsientos_Contables(int id)
        {
            var asientos_Contables = await _context.Asientos_Contables.FindAsync(id);

            if (asientos_Contables == null)
            {
                return NotFound();
            }

            return asientos_Contables;
        }

        // PUT: api/AContables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsientos_Contables(int id, Asientos_Contables asientos_Contables)
        {
            if (id != asientos_Contables.ID)
            {
                return BadRequest();
            }

            _context.Entry(asientos_Contables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Asientos_ContablesExists(id))
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

        // POST: api/AContables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asientos_Contables>> PostAsientos_Contables(Asientos_Contables asientos_Contables)
        {
            _context.Asientos_Contables.Add(asientos_Contables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsientos_Contables", new { id = asientos_Contables.ID }, asientos_Contables);
        }

        // DELETE: api/AContables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsientos_Contables(int id)
        {
            var asientos_Contables = await _context.Asientos_Contables.FindAsync(id);
            if (asientos_Contables == null)
            {
                return NotFound();
            }

            _context.Asientos_Contables.Remove(asientos_Contables);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Asientos_ContablesExists(int id)
        {
            return _context.Asientos_Contables.Any(e => e.ID == id);
        }
    }
}
