using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Models;
using VerzamelingFinished.ViewModels;

namespace VerzamelingFinished.Controllers
{
    public class CardsController : Controller
    {
        private readonly DBcontext _context;

        public CardsController(DBcontext context)
        {
            _context = context;
        }

        // GET: Cards

        public async Task<IActionResult> Index(string sortOrder)
        {

            // Check if the user is authenticated
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                // If not authenticated, redirect to the login page
                return RedirectToAction("Login", "Account");
            }

            // Fetch all cards from the database
            var cards = from c in _context.cards
                        select c;

            // Apply sorting based on the sortOrder parameter
            switch (sortOrder)
            {

                case "id_asc":
                    cards = cards.OrderBy(c => c.Id);
                    break;
                case "id_desc":
                    cards = cards.OrderByDescending(c => c.Id);
                    break;
                case "name_asc":
                    cards = cards.OrderBy(c => c.Name);
                    break;
                case "name_desc":
                    cards = cards.OrderByDescending(c => c.Name);
                    break;
                case "price_asc":
                    cards = cards.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    cards = cards.OrderByDescending(c => c.Price);
                    break;
                case "quantity_asc":
                    cards = cards.OrderBy(c => c.Quantity);
                    break;
                case "quantity_desc":
                    cards = cards.OrderByDescending(c => c.Quantity);
                    break;
                default:
                    cards = cards.OrderBy(c => c.Name); // Default sorting
                    break;

                case "element_asc":
                    cards = cards.OrderBy(c => c.Element);
                    break;

                case "element_desc":
                    cards = cards.OrderByDescending(c => c.Element);
                    break;


            }

            // Return the sorted list of cards to the view
            return View(await cards.ToListAsync());
        }



        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            var decks = _context.decks.ToList();

            ViewData["Decks"] = decks.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Id.ToString()

            }).ToList();
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Card card, int[] DeckIds)
        {
            if (ModelState.IsValid)
            {
                
                    // Fetch the selected decks from the database
                    var selectedDecks = await _context.decks
                        .Where(d => DeckIds.Contains(d.Id))
                        .ToListAsync();

                    // Assign the selected decks to the card
                    card.Decks = selectedDecks;

                    // Add the new card to the database
                    _context.cards.Add(card);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
            }

            var decks = _context.decks.ToList();
            ViewData["Decks"] = decks.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            return View(card);
        }


        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var card = await _context.cards
        .Include(c => c.Decks) // Include the decks associated with the card
        .FirstOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                return NotFound();
            }

            // Set ViewData with the available decks
            ViewData["AvailableDecks"] = await _context.decks.ToListAsync();

            // Prepare selected deck IDs
            ViewData["SelectedDeckIds"] = card.Decks.Select(d => d.Id).ToList();

            return View(card); // Pass the card object to the view
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, string name, List<int> selectedDeckIds)
        {
            if (ModelState.IsValid)
            {
                var card = await _context.cards
                    .Include(c => c.Decks)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (card == null)
                {
                    return NotFound();
                }

                // Update card properties
                card.Name = name;

                // Clear existing deck associations
                card.Decks.Clear();

                // Add selected decks
                if (selectedDeckIds != null)
                {
                    foreach (var deckId in selectedDeckIds)
                    {
                        var deck = await _context.decks.FindAsync(deckId);
                        if (deck != null)
                        {
                            card.Decks.Add(deck);
                        }
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = card.Id });
            }

            // If model state is invalid, set ViewData again
            ViewData["AvailableDecks"] = await _context.decks.ToListAsync();
            ViewData["SelectedDeckIds"] = selectedDeckIds;

            return View(await _context.cards.FindAsync(id)); // Return the card to the view for corrections
        }


        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.cards.FindAsync(id);
            if (card != null)
            {
                _context.cards.Remove(card);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.cards.Any(e => e.Id == id);
        }
    }
}
