using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Models;

namespace VerzamelingFinished.Controllers
{
    public class DecksController : Controller
    {
        private readonly DBcontext _context;

        public DecksController(DBcontext context)
        {
            _context = context;
        }

        // GET: Decks
        public async Task<IActionResult> Index(string sortOrder)
        {

            // Check if the user is authenticated
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                // If not authenticated, redirect to the login page
                return RedirectToAction("Login", "Account");
            }



            var deck = await _context.decks
                 .Include(d => d.Cards) // Include the associated cards
                 .ToListAsync();
            
            
               
             
          
            if (deck == null)
            {
                return NotFound();
            }

            var decks = from d in  deck
                        select d;

                




            switch (sortOrder)
            {

                case "id_asc":
                    decks = decks.OrderBy(c => c.Id);
                    break;
                case "id_desc":
                    decks = decks.OrderByDescending(c => c.Id);
                    break;

                case "name_asc":
                    decks = decks.OrderBy(d => d.Name);
                break;

                case "name_desc":
                    decks = decks.OrderByDescending(d => d.Name);
                    break;
                




            }


            return View(decks.ToList());
        }

        // GET: Decks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.decks
                .Include(d => d.Cards) // Include the associated cards
                .FirstOrDefaultAsync(d => d.Id == id);

            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // GET: Decks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Image,CardCount")] Deck deck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deck);
        }

        // GET: Decks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }
            return View(deck);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image,CardCount")] Deck deck)
        {
            if (id != deck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckExists(deck.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deck);
        }

        // GET: Decks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.decks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCardFromDeck(int deckId, int cardId)
        {
            // Find the deck
            var deck = await _context.decks
                .Include(d => d.Cards) // Include the cards in the deck
                .FirstOrDefaultAsync(d => d.Id == deckId);

            if (deck == null)
            {
                return NotFound();
            }

            // Find the card to remove
            var cardToRemove = deck.Cards.FirstOrDefault(c => c.Id == cardId);
            if (cardToRemove == null)
            {
                return NotFound(); // if the card doesn't exist in the deck
            }

            // Remove the card from the deck
            deck.Cards.Remove(cardToRemove);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = deckId }); // Redirect to the deck details page
        }




        // POST: Decks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deck = await _context.decks.FindAsync(id);
            if (deck != null)
            {
                _context.decks.Remove(deck);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckExists(int id)
        {
            return _context.decks.Any(e => e.Id == id);
        }
    }
}
