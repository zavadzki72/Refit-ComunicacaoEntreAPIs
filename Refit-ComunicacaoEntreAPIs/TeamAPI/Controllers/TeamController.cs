using Microsoft.AspNetCore.Mvc;
using Refit;
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
            var token = await _playerService.Authorize("palmeiras_nao_tem_mundial");

            var playerService = RestService.For<IPlayerService>("https://localhost:7012",
                new RefitSettings 
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(token.Content)
                }
            );

            var resultPlayer = await playerService.GetPlayersOfTeam(team);

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
                Name = "S?o Paulo",
                Apelido = "Soberano",
                Players = playerResponse
            };
        }
    }
}