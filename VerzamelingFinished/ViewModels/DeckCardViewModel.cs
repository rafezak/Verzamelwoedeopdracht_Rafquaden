using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using VerzamelingFinished.Models;

namespace VerzamelingFinished.ViewModels

{
    public class DeckCardViewModel
    {
        public Card Card { get; set; }

        public Deck Deck { get; set; } 

        public IEnumerable<SelectListItem> Decks { get; set; }

      

    }
}
