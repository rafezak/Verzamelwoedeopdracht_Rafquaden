using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VerzamelingFinished.Models;
using VerzamelingFinished.Services;

namespace VerzamelingFinished.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Pokeservice _pokemonService;

        public HomeController(ILogger<HomeController> logger, Pokeservice pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService ?? throw new ArgumentNullException(nameof(pokemonService));

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Mydecks()
        {
            return View();
        }

        public IActionResult Cards()
        {
            return View();
        }

        //public IActionResult GetCoins()
        //{
        //    return View();
        //}

        public IActionResult PokedexTest()
        {
            return View();
        }

        public async Task<IActionResult> GetCoins(string name)
        {
            Card pokemon = null;

            // Check if a name was submitted
            if (!string.IsNullOrEmpty(name))
            {
                // Call the service to fetch the Pokémon data dynamically
                pokemon = await _pokemonService.GetPokemonByName(name);

                // If no Pokémon was found, set an error message
                if (pokemon == null)
                {
                    ViewBag.ErrorMessage = $"Could not find a Pokémon named '{name}'.";
                }
            }

            return View(pokemon);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}