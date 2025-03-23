using Microsoft.AspNetCore.Mvc;

namespace PingPong.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GetResult([FromBody] int result)
        {
            Console.WriteLine($"Otrzymano wynik: {result}");
            return Ok(new { message = "Wynik zapisany poprawnie" });
        }
    }
}
