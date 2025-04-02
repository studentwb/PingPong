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
        public IActionResult PostResult([FromBody] int result)
        {
            Console.WriteLine($"Otrzymano wynik: {result}");
            return Ok(new { message = "Wynik zapisany poprawnie" });
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { result = 0 });
        }
    }
}
