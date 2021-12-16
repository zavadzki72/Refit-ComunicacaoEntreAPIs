using Microsoft.AspNetCore.Mvc;
using TeamAPI.Model;
using TeamAPI.Services;

namespace TeamAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public TeamController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string team)
        {
            var resultPlayer = await _playerService.GetPlayersOfTeam(team);

            if (!resultPlayer.IsSuccessStatusCode)
            {
                return BadRequest(resultPlayer.Error?.Content);
            }

            var result = GenerateTeamWithPlayers(resultPlayer.Content);
            return Ok(result);
        }

        private static Team GenerateTeamWithPlayers(List<PlayerResponse>? playerResponse)
        {
            return new Team
            {
                Name = "São Paulo",
                Apelido = "Soberano",
                Players = playerResponse
            };
        }
    }
}