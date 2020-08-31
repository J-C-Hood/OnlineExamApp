using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExamApp.Model;

namespace OnlineExamApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedtesttablesController : ControllerBase
    {
        private readonly examlibrarydbContext _context;

        public AssignedtesttablesController(examlibrarydbContext context)
        {
            _context = context;
        }

        // GET: api/Assignedtesttables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignedtesttable>>> GetAssignedtesttable()
        {
            return await _context.Assignedtesttable.ToListAsync();
        }

        // GET: api/Assignedtesttables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignedtesttable>> GetAssignedtesttable(int id)
        {
            var assignedtesttable = await _context.Assignedtesttable.FindAsync(id);

            if (assignedtesttable == null)
            {
                return NotFound();
            }

            return assignedtesttable;
        }

        // PUT: api/Assignedtesttables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignedtesttable(int id, Assignedtesttable assignedtesttable)
        {
            if (id != assignedtesttable.AssignedTestId)
            {
                return BadRequest();
            }

            _context.Entry(assignedtesttable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedtesttableExists(id))
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

        // POST: api/Assignedtesttables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Assignedtesttable>> PostAssignedtesttable(Assignedtesttable assignedtesttable)
        {
            _context.Assignedtesttable.Add(assignedtesttable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignedtesttable", new { id = assignedtesttable.AssignedTestId }, assignedtesttable);
        }

        // DELETE: api/Assignedtesttables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assignedtesttable>> DeleteAssignedtesttable(int id)
        {
            var assignedtesttable = await _context.Assignedtesttable.FindAsync(id);
            if (assignedtesttable == null)
            {
                return NotFound();
            }

            _context.Assignedtesttable.Remove(assignedtesttable);
            await _context.SaveChangesAsync();

            return assignedtesttable;
        }

        private bool AssignedtesttableExists(int id)
        {
            return _context.Assignedtesttable.Any(e => e.AssignedTestId == id);
        }
    }
}
