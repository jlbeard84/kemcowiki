using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;

        public GameController(
            ILogger<GameController> logger,
            IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _gameService.GetAllGames();
            return Ok(result);
        }


        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetSingle(string gameId)
        {
            var result = await _gameService.GetSingleGame(gameId);
            return Ok(result);
        }
    }
}