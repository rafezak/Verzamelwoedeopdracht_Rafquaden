using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VerzamelingFinished.Models;
namespace VerzamelingFinished.Services
{
    public class Pokeservice
    {
        private readonly HttpClient _httpClient;

        public Pokeservice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> GetPokemonByName(string name)
        {
            try

            {
                var url = $"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(content);

                    // Create a ViewModel to pass data to the view
                    var pokemon = new Pokemon
                    {

                        Name = result.name,
                        image = result.sprites.front_default,


                    };

                    return pokemon;
                }
            }

            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error fetching data for {name}: {ex.Message}");
            }


            return null;
        }
    }
}
