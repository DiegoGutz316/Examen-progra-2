using Newtonsoft.Json.Linq;
using Examen_progra_2.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Examen_progra_2.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            var json = JObject.Parse(response);

            var pokemon = new Pokemon
            {
                Name = json["name"].ToString(),
                Type = json["types"][0]["type"]["name"].ToString(),
                SpriteUrl = json["sprites"]["front_default"].ToString(),
                Moves = json["moves"].Select(m => m["move"]["name"].ToString()).ToList()
            };

            return pokemon;
        }
    }
}
