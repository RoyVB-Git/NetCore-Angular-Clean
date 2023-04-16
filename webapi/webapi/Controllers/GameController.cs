using logic.Dtos;
using logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gameDto = await _gameService.GetById(id).ConfigureAwait(false);

            return Ok(gameDto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var gameDtos = await _gameService.GetAll().ConfigureAwait(false);

            return Ok(gameDtos);
        }
    }
}
