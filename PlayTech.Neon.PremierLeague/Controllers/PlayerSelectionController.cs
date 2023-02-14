using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using PlayTech.Neon.PremierLeague.Domain.Services;

namespace PlayTech.Neon.PremierLeague.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerSelectionController : ControllerBase
    {
        private readonly ILogger<PlayerSelectionController> _logger;
        private readonly IPlayerSelectionService _playerSelectionService;

        public PlayerSelectionController(ILogger<PlayerSelectionController> logger,
            IPlayerSelectionService playerSelectionService)
        {
            _logger = logger;
            _playerSelectionService = playerSelectionService;
        }

        [HttpGet("players")]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(new List<string>());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AddPlayerSelectionModel playerSelectionModel)
        {
            try
            {
                _playerSelectionService.AddPlayerSelection(playerSelectionModel.UserId, playerSelectionModel.PlayerId);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserPlayers(string userId)
        {
            try
            {
                var players = _playerSelectionService.GetPlayersForUser(userId);
                return StatusCode(StatusCodes.Status200OK, players);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}