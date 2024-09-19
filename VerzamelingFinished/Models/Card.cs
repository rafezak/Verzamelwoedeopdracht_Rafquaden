using System.ComponentModel.DataAnnotations;
namespace VerzamelingFinished.Models;


    public class Card
    {
        

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Element { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }



        public int DeckId { get; set; }

        public Deck Deck { get; set; }




    }

