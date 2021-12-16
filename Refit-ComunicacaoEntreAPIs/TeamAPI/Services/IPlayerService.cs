using Refit;
using TeamAPI.Model;

namespace TeamAPI.Services
{
    public interface IPlayerService
    {
        [Get("/Player/GetPlayersOfTeam/{team}")]
        Task<ApiResponse<List<PlayerResponse>>> GetPlayersOfTeam(string team);
    }
}
