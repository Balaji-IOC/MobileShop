using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Host.Model;

namespace WebApi_Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoesController : ControllerBase
    {
        private readonly Employee _context;

        public DemoesController(Employee context)
        {
            _context = context;
        }

        // GET: api/Demoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demo>>> GetDemos()
        {
            return await _context.Demos.ToListAsync();
        }

        // GET: api/Demoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Demo>> GetDemo(int id)
        {
            var demo = await _context.Demos.FindAsync(id);

            if (demo == null)
            {
                return NotFound();
            }

            return demo;
        }

        // PUT: api/Demoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemo(int id, Demo demo)
        {
            if (id != demo.ID)
            {
                return BadRequest();
            }

            _context.Entry(demo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemoExists(id))
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

        // POST: api/Demoes
        [HttpPost]
        public async Task<ActionResult<Demo>> PostDemo(Demo demo)
        {
            _context.Demos.Add(demo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemo", new { id = demo.ID }, demo);
        }

        // DELETE: api/Demoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Demo>> DeleteDemo(int id)
        {
            var demo = await _context.Demos.FindAsync(id);
            if (demo == null)
            {
                return NotFound();
            }

            _context.Demos.Remove(demo);
            await _context.SaveChangesAsync();

            return demo;
        }

        private bool DemoExists(int id)
        {
            return _context.Demos.Any(e => e.ID == id);
        }
    }
}
