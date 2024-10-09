using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Models;
using VerzamelingFinished.Services;


namespace VerzamelingFinished.Controllers
{
    public class CardsController : Controller
    {
        private readonly Pokeservice _pokemonService;

        private readonly DBcontext _context;
        public CardsController(DBcontext context, Pokeservice pokemonService)
        {
            _context = context;
            _pokemonService = pokemonService;
        }



        
        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _context.cards.Include(a => a.Deck).ToListAsync());
        }

        // GET: Cards/Details/5
        
        
            // Details by ID (for int)
            [HttpGet("details/{id:int}")]
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

            // Details by Name (for string)
            
            public async Task<IActionResult> Details(int id)
            {
                Card pokemon = null;

                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    var card = _context.cards.FirstOrDefaultAsync(m => m.Id == id);
                // Call the service to fetch the Pokémon data dynamically
                pokemon = await _pokemonService.GetPokemonByName(card.Result.Name);

                    if (pokemon == null)
                    {
                        ViewBag.ErrorMessage = $"Could not find a Pokémon named '{card.Result.Name}'.";
                    }
                }

                return View(pokemon);
            }
        







        // GET: Cards/Create
        public IActionResult Create()
        {
            ViewData["DeckId"] = new SelectList(_context.decks, "Id", "Name");


            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Element,Price,Quantity,Image,DeckId")] Card card)
        {
            if (ModelState.IsValid)

            {
                _context.Add(card);
                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["DeckId"] = new SelectList(_context.decks, "Id", "Id", card.DeckId);

            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();

            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Element,Price,Quantity")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
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
            return View(card);
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
