using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Models;

namespace VerzamelingFinished.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsAPIController : ControllerBase
    {
        private readonly DBcontext _context;

        public CardsAPIController(DBcontext context)
        {
            _context = context;
        }

        // GET: api/CardsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> Getcards()
        {
            return await _context.cards.ToListAsync();
        }

        // GET: api/CardsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _context.cards.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        // PUT: api/CardsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/CardsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            _context.cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        // DELETE: api/CardsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _context.cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.cards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(int id)
        {
            return _context.cards.Any(e => e.Id == id);
        }
    }
}
