using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace VerzamelingFinished.Models;


    public class Card
    {
        

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Element { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; }

       

         [JsonIgnore]
        public virtual ICollection<Deck> Decks { get; set; } = new List<Deck>();








}

