using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Games.Commands.SaveGame;
using Server.Application.Games.Queries.GetGames;
using Server.Domain.Entites;

namespace PingPong.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostResult([FromBody] Game game)
        {
            try
            {
                game.Date = DateTime.UtcNow;
                var commandResult = await mediator.Send(new SaveGameCommand { game = game });
                return Ok(new { message = "Wynik zapisany poprawnie " });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var games= await mediator.Send(new GetGamesQuery());
            return Ok(games);
        }
    }
}
