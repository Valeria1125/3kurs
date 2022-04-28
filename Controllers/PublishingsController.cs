using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cousework_3_kurs.db;
using couse_work_web.ModelsApi;

namespace Cousework_3_kurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishingsController : ControllerBase
    {
        private readonly cousework3kursContext _context;

        public PublishingsController(cousework3kursContext context)
        {
            _context = context;
        }

        // GET: api/Publishings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublishingApi>>> GetPublishings()
        {
            return await _context.Publishings.Select(s => (PublishingApi)s).ToListAsync();
        }

        // GET: api/Publishings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublishingApi>> GetPublishing(int id)
        {
            var publishing = await _context.Publishings.FindAsync(id);

            if (publishing == null)
            {
                return NotFound();
            }

            return (PublishingApi)publishing;
        }

        // PUT: api/Publishings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishing(int id, Publishing publishing)
        {
            if (id != publishing.Id)
            {
                return BadRequest();
            }

            var oldpublishing = await _context.Publishings.FindAsync(id);
            oldpublishing.PublishingHouse = publishing.PublishingHouse;

            _context.Entry(oldpublishing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishingExists(id))
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

        // POST: api/Publishings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublishingApi>> PostPublishing(PublishingApi publishing)
        {
            _context.Publishings.Add((Publishing)publishing);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPublishing", new { id = publishing.Id }, (PublishingApi)publishing);
        }

        // DELETE: api/Publishings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublishing(int id)
        {
            var publishing = await _context.Publishings.FindAsync(id);
            if (publishing == null)
            {
                return NotFound();
            }

            _context.Publishings.Remove(publishing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublishingExists(int id)
        {
            return _context.Publishings.Any(e => e.Id == id);
        }
    }
}
