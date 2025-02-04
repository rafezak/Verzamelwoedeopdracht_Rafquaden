﻿using System.Text.Json.Serialization;

namespace VerzamelingFinished.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [JsonIgnore]
        public virtual ICollection<Card>? Cards { get; set; }

        public int? CardCount { get; set; }


    }
}
