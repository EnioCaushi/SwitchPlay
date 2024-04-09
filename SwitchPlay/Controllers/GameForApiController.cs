using Microsoft.AspNetCore.Mvc;
using SwitchPlay.Data;
using SwitchPlay.Models;
using SwitchPlay.Services;

namespace SwitchPlay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameForApiController : Controller
{
        private readonly SwitchPlayContext _switchPlayContext;
        private readonly IGameService _gameService;
        
        public GameForApiController(IGameService gameService, SwitchPlayContext switchPlayContext)
        {
            _gameService = gameService;
            _switchPlayContext = switchPlayContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>>  Index()
        {
            return _switchPlayContext.Games.ToList();
        }
} 