using Microsoft.AspNetCore.Mvc;
using Examen_progra_2.Models;
using Examen_progra_2.Services;
using System.Threading.Tasks;

namespace Examen_progra_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokemon(string name)
        {
            var pokemon = await _pokemonService.GetPokemonAsync(name);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }
    }
}
