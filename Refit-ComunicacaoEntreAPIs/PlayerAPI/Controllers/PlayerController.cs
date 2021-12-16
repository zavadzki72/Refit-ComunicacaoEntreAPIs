using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayerAPI.Model;

namespace PlayerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        readonly List<Player> _players = new()
        {
            new Player
            {
                Name = "Thiago Volpi",
                Rate = 78
            },
            new Player
            {
                Name = "Robert Arboleda",
                Rate = 87
            },
            new Player
            {
                Name = "Miranda",
                Rate = 88
            },
            new Player
            {
                Name = "Reinaldo",
                Rate = 80
            },
            new Player
            {
                Name = "Igor Vinicius",
                Rate = 70
            },
            new Player
            {
                Name = "Gabriel Neves",
                Rate = 82
            },
            new Player
            {
                Name = "Rodrigo Nestor",
                Rate = 84
            },
            new Player
            {
                Name = "Gabriel Sara",
                Rate = 82
            },
            new Player
            {
                Name = "Marquinhos",
                Rate = 78
            },
            new Player
            {
                Name = "Jhonata Calleri",
                Rate = 83
            },
            new Player
            {
                Name = "Emiliano Rigonni",
                Rate = 86
            },
            new Player
            {
                Name = "Pablo",
                Rate = -100
            },
        };

        [HttpGet("GetPlayersOfTeam/{team}")]
        public IActionResult GetPlayersOfTeam(string team)
        {
            return team switch
            {
                "Sao Paulo" => Ok(_players),
                "Palmeiras" => BadRequest("O Palmeiras nao tem mundial, O Palmeiras nao tem mundial, nao tem copinha nao tem mundial, nao tem copinha e nem mundial\nhttps://www.youtube.com/watch?v=S9Ixa-4zCp8\n"),
                _ => BadRequest("Só trabalhamos com times de qualidade"),
            };
        }
    }
}