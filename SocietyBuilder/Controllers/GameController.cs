using Microsoft.AspNetCore.Mvc;
using SocietyBuilder.Services.GameCore;

namespace SocietyBuilder.Controllers
{
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameCore _gameCore;
        public GameController(IGameCore gameCore)
        {
            _gameCore = gameCore;
        }

        [HttpGet]
        public OkResult NewGame(string difficult)
        {
            _gameCore.NewGame(difficult);
            return Ok();
        }
    }
}
