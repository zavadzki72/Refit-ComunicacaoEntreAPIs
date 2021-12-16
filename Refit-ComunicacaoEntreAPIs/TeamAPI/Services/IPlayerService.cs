using Refit;
using TeamAPI.Model;

namespace TeamAPI.Services
{
    public interface IPlayerService
    {
        [Get("/Player/GetPlayersOfTeam/{team}")]
        [Headers("Authorization: Bearer")]
        Task<ApiResponse<List<PlayerResponse>>> GetPlayersOfTeam(string team);

        [Get("/Auth/authorize/{password}")]
        Task<ApiResponse<string>> Authorize(string password);
    }
}
