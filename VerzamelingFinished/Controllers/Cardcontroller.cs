using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Update;
using System.Reflection.Metadata.Ecma335;
using VerzamelingFinished.Models;



namespace VerzamelingFinished.Controllers


{


    public class Cardcontroller : Controller
    {

        private readonly DBcontext _context;

    public Cardcontroller(DBcontext context)
    {
        _context = context;
    }

    
        public IActionResult Index()
        {
            var cards = _context.cards.ToList();
            return View(cards);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var card = new Card();
            
            return View(card);
        }

        [HttpPost]
        public IActionResult Create(Card card)
        {
            if (ModelState.IsValid)
            {


                _context.cards.Add(card);
                _context.SaveChanges();
                return RedirectToAction("Read");
            }
            return View(card);
        }


        public IActionResult Read()
        {
            var cards = _context.cards.ToList();
            return View(cards);
        }

        public IActionResult Delete(int id)
        {
            var card = _context.cards.Find(id);
            _context.cards.Remove(card);
            _context.SaveChanges();
            return RedirectToAction("Read");
        }

        public IActionResult GetbyID(int id)
        {
            var card = _context.cards.Find(id);
            return View(card);
        }
    }

}
  
