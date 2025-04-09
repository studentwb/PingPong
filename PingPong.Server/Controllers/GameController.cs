using Microsoft.AspNetCore.Mvc;
using Server.Application.Games;
using Server.Domain.Entites;
using Server.Domain.Repositories;

namespace PingPong.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController(IGamesService gamesService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostResult([FromBody] Game game)
        {
            try
            {
                game.Date = DateTime.UtcNow;
                await gamesService.Post(game);
                return Ok(new { message = "Wynik zapisany poprawnie" });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var games= await gamesService.GetAllGames();
            return Ok(games);
        }
    }
}
